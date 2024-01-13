using EscanerSC500.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EscanerSC500
{
    public partial class Form1 : Form
    {

        SerialPort serial;
        string portname;
        string dataIN;
        Process pc;

        public Form1()
        {
            InitializeComponent();
            notify_options.ContextMenuStrip = new ContextMenuStrip();
            notify_options.ContextMenuStrip.Items.Add("Opciones", null, MenuOpciones_Click);
            notify_options.ContextMenuStrip.Items.Add("Salir", null, MenuSalir_Click);

            /**** Tab (Propiedades) ****/
            serviceURLTextbox.Text = Properties.Settings.Default.ServiceURL;
            clienteAttrTextbox.Text = Properties.Settings.Default.ClienteAttr;
            sucursalAttrTextbox.Text = Properties.Settings.Default.SucursalAttr;
            deviceAttrTextbox.Text = Properties.Settings.Default.DeviceAttr;
            deviceIdTextbox.Text = Properties.Settings.Default.DeviceID;

            /**** Tab (Dispositivo) ****/
            productIdTextbox.Text = Properties.Settings.Default.ProductID;
            vendorIdTextbox.Text = Properties.Settings.Default.VendorID;

            /**** Tab (Sucursales) ****/
            List<string> sucursal_names = Properties.Settings.Default.SucursalArray ?? new List<string>();
            List<int> sucursal_ids = Properties.Settings.Default.SucursalIDArray ?? new List<int>();

            // Sucursales vacías (primera vez que se abre el programa) - Valores por defecto
            if (sucursal_names.Count() == 0)
            {
                Add_Default_Sucursales();
            }

            Render_Combobox_List();
            // Select sucursal from properties
            sucursalSelect.SelectedIndex = Properties.Settings.Default.Sucursal;

            //TRY SERIAL PORT
            serialChangeTimer.Start();

            ContextMenuStrip stripmenu = new ContextMenuStrip();
            stripmenu.Items.Add("Opciones", null, MenuOpciones_Click);
            stripmenu.Items.Add("Salir", null, MenuSalir_Click);

            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Icon = Properties.Resources.AppIcon;
            trayIcon.ContextMenuStrip = stripmenu;
            trayIcon.Visible = true;

            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        void MenuOpciones_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        void MenuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Visible = false;
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        void Add_Default_Sucursales()
        {
            List<string> snames = new List<string>();
            List<int> sids = new List<int>();

            snames.Add("Talkin Heads Zona 10");
            snames.Add("Talkin Heads Pradera Concepcion");
            snames.Add("Talkin Heads Decima");
            snames.Add("Talkin Heads Cayala Nogales");

            sids.Add(1);
            sids.Add(3);
            sids.Add(6);
            sids.Add(8);

            Properties.Settings.Default.SucursalArray = snames;
            Properties.Settings.Default.SucursalIDArray = sids;
            Properties.Settings.Default.Save();
        }

        private void Render_Combobox_List()
        {
            int count = 0;
            List<string> s_names = Properties.Settings.Default.SucursalArray ?? new List<string>();
            List<int> s_ids = Properties.Settings.Default.SucursalIDArray ?? new List<int>();
            foreach (string name in s_names)
            {
                sucursalSelect.Items.Add(new ComboboxItem
                {
                    Text = name,
                    Value = s_ids.ElementAt(count),
                    Index = count
                });
                addedSucursalCombo.Items.Add(new ComboboxItem
                {
                    Text = name,
                    Value = s_ids.ElementAt(count),
                    Index = count
                });
                count++;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            /*if (serial != null)
            {
                serial.Dispose();
                portname = "";
            }
            TryConnectSerial();*/
            OpenURLInWindow("0");
        }

        void TryConnectSerial()
        {
            if (serial == null || string.IsNullOrEmpty(portname))
            {
                // NO SE HA CONECTADO NINGÚN SERIAL
                CheckPortExist();
            }
            else
            {
                if (!serial.IsOpen)
                {
                    serial.Dispose();
                    portname = "";
                    serialStateLabel.Text = "Estado: Sin conectar.";
                }
                else
                {
                    serialStateLabel.Text = "Estado: Escuchando puerto " + portname;
                }
            }
        }

        void CheckPortExist()
        {
            portname = ComPortNames(Properties.Settings.Default.VendorID, Properties.Settings.Default.ProductID);
            if (!string.IsNullOrEmpty(portname))
            {
                serial = new SerialPort(portname, 9600, Parity.None, 8, StopBits.One);
                serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                try
                {
                    serial.Open();
                }
                catch (FileNotFoundException e)
                {
                    logTextbox.AppendText("No hay dispositivo disponible en " + portname);
                    logTextbox.AppendText(Environment.NewLine);
                }
                catch (Exception ex)
                {
                    logTextbox.AppendText("Excepción desconocida: " + ex.Message);
                    logTextbox.AppendText(Environment.NewLine);
                }

                if (serial.IsOpen)
                {
                    serialTextbox.Text = portname;
                    serialStateLabel.Text = "Estado: Escuchando puerto " + portname;
                }
            }
            else
            {
                serialTextbox.Text = "";
                serialStateLabel.Text = "Estado: Sin conectar.";
            }
        }

        string ComPortNames(string VID, string PID)
        {
            string pattern = string.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (string s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (string s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (string s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }

            if (comports.Count > 0)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comports.Contains(s))
                    {
                        // PORT COM NAME FOUND (s)
                        return s;
                    }
                }
            }

            return "";
        }

        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            SerialPort sp = (SerialPort)sender;
            dataIN = sp.ReadExisting();

            //Debug.WriteLine(dataIN);
            this.Invoke(new EventHandler(ShowDataInForm));
        }

        void ShowDataInForm(object sender, EventArgs e)
        {

            logTextbox.AppendText("Mensaje puerto serial: " + dataIN);

            Regex id_cliente_pattern = new Regex(@"id_cliente=[1-9][0-9]+");
            Match regex_match = id_cliente_pattern.Match(dataIN);
            if (regex_match.Success)
            {
                string clientcode = regex_match.Value.Substring(11);
                logTextbox.AppendText("Código cliente: " + clientcode);
                logTextbox.AppendText(Environment.NewLine);

                // Abrir explorador web con código de cliente
                OpenURLInWindow(clientcode);
            }
            else
            {
                logTextbox.AppendText("Código cliente: Formato de código QR inválido.");
                logTextbox.AppendText(Environment.NewLine);
                //QR INVÁLIDO (EL QR HACE REFERENCIA A UN ID_CLIENTE NO EXISTENTE O EL FORMATO DE URL NO ES VÁLIDO)
                OpenURLInWindow("0");
            }
        }

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
            IntPtr lParam);

        void OpenURLInWindow(string id_param)
        {

            /*if(pc != null && !pc.HasExited)
            {
                pc.CloseMainWindow();
                pc.Close();
                //pc.Kill();
            }*/

            // AGREGAR FUNCIÓN THROTTLE PARA CUANDO ESCANEA MUY RÁPIDO (MÁS DE UNA VEZ EN POCO TIEMPO)
            // AGREGAR PROPERTY SETTINGS PARA HACER VALIDACIÓN DE PROCESOS CHROME Y THREADS, SI NO SE ACTIVA ESTA OPCIÓN SE CONSERVA EL IF DE PROCESS KILL CUANDO LA ÚNICA VENTANA/TAB DE CHROME

            foreach (Process process in Process.GetProcessesByName("chrome"))
            {
                if (process.MainWindowHandle == IntPtr.Zero) // some have no UI
                    continue;

                foreach (ProcessThread thread in Process.GetProcessById(process.Id).Threads)
                {
                    EnumThreadWindows(thread.Id,
                        (hWnd, lParam) => {
                            AutomationElement element = AutomationElement.FromHandle(hWnd);
                            try
                            {
                                Debug.WriteLine("CURRNAME: " + element.Current.Name);
                                if (element.Current.Name.Contains("SCANQR"))
                                {
                                    ((WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern)).Close();
                                }
                            }
                            catch(ElementNotAvailableException ex)
                            {
                                Debug.WriteLine("Todas las instancias de Chrome cerradas");
                            }
                            return true;
                        }, IntPtr.Zero);
                }
            }

            string base_url = Properties.Settings.Default.ServiceURL;
            string id_cliente_attr = Properties.Settings.Default.ClienteAttr;
            string id_sucursal_attr = Properties.Settings.Default.SucursalAttr;
            ComboboxItem selected = sucursalSelect.SelectedItem as ComboboxItem;
            string id_sucursal_selected = selected.Value.ToString();
            string id_device_attr = Properties.Settings.Default.DeviceAttr;
            string id_device = Properties.Settings.Default.DeviceID;

            string url = base_url + "?" + id_cliente_attr + "=" + id_param + "&" + id_sucursal_attr + "=" + id_sucursal_selected + "&" + id_device_attr + "=" + id_device;

            try
            {
                pc = Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    //url = url.Replace("&", "^&");
                    pc = Process.Start(new ProcessStartInfo(url) { UseShellExecute = true, FileName = "chrome", Arguments = url + " --new-window --window-name=\"SCANQR\"" });
                    Debug.WriteLine("PC ID: " + pc.Id.ToString());
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    pc = Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    pc = Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void btnAddSucursal_Click(object sender, EventArgs e)
        {
            string actionType = btnAddSucursal.Text;

            int s_id = Convert.ToInt32(sucursalIDTextbox.Text);
            string s_name = sucursalNombreTextbox.Text;

            List<string> sucursal_names = Properties.Settings.Default.SucursalArray ?? new List<string>();
            List<int> sucursal_ids = Properties.Settings.Default.SucursalIDArray ?? new List<int>();

            if (actionType == "Actualizar")
            {
                int index = sucursal_ids.FindIndex(x => x == s_id);
                if (index != -1)
                {
                    sucursal_names[index] = s_name;
                    ComboboxItem updated_item = new ComboboxItem
                    {
                        Text = s_name,
                        Value = s_id,
                        Index = index
                    };
                    addedSucursalCombo.Items[index] = updated_item;
                    sucursalSelect.Items[index] = updated_item;
                    Properties.Settings.Default.SucursalArray = sucursal_names;
                    Properties.Settings.Default.Save();
                    cancelEditSucursal();
                }
                else
                {
                    MessageBox.Show("No existe una sucursal con el ID " + s_id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                sucursal_names.Add(s_name);
                sucursal_ids.Add(s_id);

                // Set properties on settings
                Properties.Settings.Default.SucursalArray = sucursal_names;
                Properties.Settings.Default.SucursalIDArray = sucursal_ids;
                Properties.Settings.Default.Save();

                sucursalIDTextbox.Clear();
                sucursalNombreTextbox.Clear();

                // Update sucursales list
                addedSucursalCombo.Items.Add(new ComboboxItem
                {
                    Text = s_name,
                    Value = s_id,
                    Index = sucursal_names.Count() + 1
                });
                sucursalSelect.Items.Add(new ComboboxItem
                {
                    Text = s_name,
                    Value = s_id,
                    Index = sucursal_names.Count() + 1
                });
            }
        }

        private void btnEliminarSucursal_Click(object sender, EventArgs e)
        {
            int s_id = Convert.ToInt32(sucursalIDTextbox.Text);
            string s_name = sucursalNombreTextbox.Text;

            List<string> sucursal_names = Properties.Settings.Default.SucursalArray ?? new List<string>();
            List<int> sucursal_ids = Properties.Settings.Default.SucursalIDArray ?? new List<int>();

            int index = sucursal_ids.FindIndex(x => x == s_id);
            if (index != -1)
            {
                sucursal_names.RemoveAt(index);
                sucursal_ids.RemoveAt(index);
                addedSucursalCombo.Items.RemoveAt(index);
                sucursalSelect.Items.RemoveAt(index);
                Properties.Settings.Default.SucursalArray = sucursal_names;
                Properties.Settings.Default.SucursalIDArray = sucursal_ids;
                Properties.Settings.Default.Save();
                cancelEditSucursal();
                CheckSucursalesChange();
            }
            else
            {
                MessageBox.Show("No existe una sucursal con el ID " + s_id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addedSucursalCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MODIFICAR UNA SUCURSAL O ELIMINARLA
            if (addedSucursalCombo.SelectedItem != null)
            {
                btnAddSucursal.Text = "Actualizar";
                btnEliminarSucursal.Enabled = true;
                btnCancelarSucursal.Enabled = true;

                ComboboxItem selected = addedSucursalCombo.SelectedItem as ComboboxItem;
                sucursalIDTextbox.Enabled = false;
                sucursalIDTextbox.Text = selected.Value.ToString();
                sucursalNombreTextbox.Text = selected.Text;
            }
        }

        private void btnCancelarSucursal_Click(object sender, EventArgs e)
        {
            cancelEditSucursal();
        }

        private void cancelEditSucursal()
        {
            btnAddSucursal.Text = "Añadir";
            btnEliminarSucursal.Enabled = false;
            btnCancelarSucursal.Enabled = false;

            sucursalIDTextbox.Clear();
            sucursalIDTextbox.Enabled = true;

            sucursalNombreTextbox.Clear();
            sucursalIDTextbox.Focus();

            addedSucursalCombo.SelectedItem = null;
        }

        private void serialChangeTimer_Tick(object sender, EventArgs e)
        {
            TryConnectSerial();
        }

        private void serviceURLTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "ServiceURL");
        }

        private void clienteAttrTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "ClienteAttr");
        }

        private void sucursalAttrTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "SucursalAttr");
        }

        private void productIdTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "ProductID");
        }

        private void vendorIdTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "VendorID");
        }

        private void deviceIdTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "DeviceID");
        }

        private void deviceAttrTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTextboxProperties(sender, "DeviceAttr");
        }

        void updateTextboxProperties(object sender, string propname)
        {
            TextBox obj = (TextBox)sender;
            if (!string.IsNullOrEmpty(obj.Text))
            {
                Properties.Settings.Default[propname] = obj.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                obj.Text = Properties.Settings.Default[propname].ToString();
            }
        }

        private void logTextbox_TextChanged(object sender, EventArgs e)
        {
            //LIMPIAR LÍNEA DE LOG (DESPUÉS DE 50 QUITAR PRIMERAS 10 LÍNEAS)
            string[] lines = logTextbox.Lines;
            if (lines.Length > 50)
            {
                //Remover primer línea
                string[] newlines = lines.Skip(10).ToArray();
                logTextbox.Lines = newlines;
            }
        }

        void CheckSucursalesChange()
        {
            if (sucursalSelect.SelectedIndex != -1)
            {
                Properties.Settings.Default.Sucursal = sucursalSelect.SelectedIndex;
                Properties.Settings.Default.Save();
            }
            else
            {
                if (sucursalSelect.Items.Count == 0)
                {
                    //Regresar a los default
                    Add_Default_Sucursales();
                    Render_Combobox_List();
                }

                Properties.Settings.Default.Sucursal = 0;
                Properties.Settings.Default.Save();
                sucursalSelect.SelectedIndex = 0;
            }
        }

        private void sucursalSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSucursalesChange();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Visible = false;
            WindowState = FormWindowState.Minimized;
        }
    }
}
