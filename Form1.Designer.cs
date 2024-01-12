namespace EscanerSC500
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnConectar = new Button();
            tabProperties = new TabControl();
            tabPropertiesInside = new TabPage();
            deviceIdTextbox = new TextBox();
            label14 = new Label();
            deviceAttrTextbox = new TextBox();
            label13 = new Label();
            sucursalAttrTextbox = new TextBox();
            clienteAttrTextbox = new TextBox();
            serviceURLTextbox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            sucursalSelect = new ComboBox();
            label4 = new Label();
            tabPage2 = new TabPage();
            serialTextbox = new TextBox();
            vendorIdTextbox = new TextBox();
            productIdTextbox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            serialStateLabel = new Label();
            logTab = new TabPage();
            logTextbox = new TextBox();
            tabPage1 = new TabPage();
            btnCancelarSucursal = new Button();
            btnEliminarSucursal = new Button();
            addedSucursalCombo = new ComboBox();
            label1 = new Label();
            btnAddSucursal = new Button();
            sucursalNombreTextbox = new TextBox();
            label12 = new Label();
            sucursalIDTextbox = new TextBox();
            label11 = new Label();
            btnAceptar = new Button();
            serialChangeTimer = new System.Windows.Forms.Timer(components);
            notify_options = new NotifyIcon(components);
            tabProperties.SuspendLayout();
            tabPropertiesInside.SuspendLayout();
            tabPage2.SuspendLayout();
            logTab.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(303, 98);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(118, 23);
            btnConectar.TabIndex = 3;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // tabProperties
            // 
            tabProperties.Controls.Add(tabPropertiesInside);
            tabProperties.Controls.Add(tabPage2);
            tabProperties.Controls.Add(logTab);
            tabProperties.Controls.Add(tabPage1);
            tabProperties.Location = new Point(12, 12);
            tabProperties.Name = "tabProperties";
            tabProperties.SelectedIndex = 0;
            tabProperties.Size = new Size(442, 219);
            tabProperties.TabIndex = 7;
            // 
            // tabPropertiesInside
            // 
            tabPropertiesInside.Controls.Add(deviceIdTextbox);
            tabPropertiesInside.Controls.Add(label14);
            tabPropertiesInside.Controls.Add(deviceAttrTextbox);
            tabPropertiesInside.Controls.Add(label13);
            tabPropertiesInside.Controls.Add(sucursalAttrTextbox);
            tabPropertiesInside.Controls.Add(clienteAttrTextbox);
            tabPropertiesInside.Controls.Add(serviceURLTextbox);
            tabPropertiesInside.Controls.Add(label7);
            tabPropertiesInside.Controls.Add(label6);
            tabPropertiesInside.Controls.Add(label5);
            tabPropertiesInside.Controls.Add(sucursalSelect);
            tabPropertiesInside.Controls.Add(label4);
            tabPropertiesInside.Location = new Point(4, 24);
            tabPropertiesInside.Name = "tabPropertiesInside";
            tabPropertiesInside.Padding = new Padding(3);
            tabPropertiesInside.Size = new Size(434, 191);
            tabPropertiesInside.TabIndex = 0;
            tabPropertiesInside.Text = "Propiedades";
            tabPropertiesInside.UseVisualStyleBackColor = true;
            // 
            // deviceIdTextbox
            // 
            deviceIdTextbox.Location = new Point(197, 156);
            deviceIdTextbox.Name = "deviceIdTextbox";
            deviceIdTextbox.Size = new Size(224, 23);
            deviceIdTextbox.TabIndex = 11;
            deviceIdTextbox.TextChanged += deviceIdTextbox_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(9, 159);
            label14.Name = "label14";
            label14.Size = new Size(56, 15);
            label14.TabIndex = 10;
            label14.Text = "Device ID";
            // 
            // deviceAttrTextbox
            // 
            deviceAttrTextbox.Location = new Point(197, 98);
            deviceAttrTextbox.Name = "deviceAttrTextbox";
            deviceAttrTextbox.Size = new Size(224, 23);
            deviceAttrTextbox.TabIndex = 9;
            deviceAttrTextbox.TextChanged += deviceAttrTextbox_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(9, 101);
            label13.Name = "label13";
            label13.Size = new Size(120, 15);
            label13.TabIndex = 8;
            label13.Text = "Atributo URL (device)";
            // 
            // sucursalAttrTextbox
            // 
            sucursalAttrTextbox.Location = new Point(197, 69);
            sucursalAttrTextbox.Name = "sucursalAttrTextbox";
            sucursalAttrTextbox.Size = new Size(224, 23);
            sucursalAttrTextbox.TabIndex = 7;
            sucursalAttrTextbox.TextChanged += sucursalAttrTextbox_TextChanged;
            // 
            // clienteAttrTextbox
            // 
            clienteAttrTextbox.Location = new Point(197, 40);
            clienteAttrTextbox.Name = "clienteAttrTextbox";
            clienteAttrTextbox.Size = new Size(224, 23);
            clienteAttrTextbox.TabIndex = 6;
            clienteAttrTextbox.TextChanged += clienteAttrTextbox_TextChanged;
            // 
            // serviceURLTextbox
            // 
            serviceURLTextbox.Location = new Point(197, 10);
            serviceURLTextbox.Name = "serviceURLTextbox";
            serviceURLTextbox.Size = new Size(224, 23);
            serviceURLTextbox.TabIndex = 5;
            serviceURLTextbox.TextChanged += serviceURLTextbox_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 72);
            label7.Name = "label7";
            label7.Size = new Size(129, 15);
            label7.TabIndex = 4;
            label7.Text = "Atributo URL (sucursal)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 41);
            label6.Name = "label6";
            label6.Size = new Size(121, 15);
            label6.TabIndex = 3;
            label6.Text = "Atributo URL (cliente)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 14);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 2;
            label5.Text = "URL";
            // 
            // sucursalSelect
            // 
            sucursalSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            sucursalSelect.FormattingEnabled = true;
            sucursalSelect.Location = new Point(197, 127);
            sucursalSelect.Name = "sucursalSelect";
            sucursalSelect.Size = new Size(224, 23);
            sucursalSelect.TabIndex = 1;
            sucursalSelect.SelectedIndexChanged += sucursalSelect_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 130);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 0;
            label4.Text = "Sucursal";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(serialTextbox);
            tabPage2.Controls.Add(vendorIdTextbox);
            tabPage2.Controls.Add(productIdTextbox);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(btnConectar);
            tabPage2.Controls.Add(serialStateLabel);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(434, 191);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Dispositivo";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // serialTextbox
            // 
            serialTextbox.Enabled = false;
            serialTextbox.Location = new Point(197, 69);
            serialTextbox.Name = "serialTextbox";
            serialTextbox.Size = new Size(224, 23);
            serialTextbox.TabIndex = 15;
            // 
            // vendorIdTextbox
            // 
            vendorIdTextbox.Location = new Point(197, 40);
            vendorIdTextbox.Name = "vendorIdTextbox";
            vendorIdTextbox.Size = new Size(224, 23);
            vendorIdTextbox.TabIndex = 14;
            vendorIdTextbox.TextChanged += vendorIdTextbox_TextChanged;
            // 
            // productIdTextbox
            // 
            productIdTextbox.Location = new Point(197, 10);
            productIdTextbox.Name = "productIdTextbox";
            productIdTextbox.Size = new Size(224, 23);
            productIdTextbox.TabIndex = 13;
            productIdTextbox.TextChanged += productIdTextbox_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 72);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 12;
            label8.Text = "Puerto serial";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 41);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 11;
            label9.Text = "Vendor ID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 14);
            label10.Name = "label10";
            label10.Size = new Size(63, 15);
            label10.TabIndex = 10;
            label10.Text = "Product ID";
            // 
            // serialStateLabel
            // 
            serialStateLabel.AutoSize = true;
            serialStateLabel.Location = new Point(9, 101);
            serialStateLabel.Name = "serialStateLabel";
            serialStateLabel.Size = new Size(45, 15);
            serialStateLabel.TabIndex = 8;
            serialStateLabel.Text = "Estado:";
            // 
            // logTab
            // 
            logTab.Controls.Add(logTextbox);
            logTab.Location = new Point(4, 24);
            logTab.Name = "logTab";
            logTab.Padding = new Padding(3);
            logTab.Size = new Size(434, 191);
            logTab.TabIndex = 2;
            logTab.Text = "Log";
            logTab.UseVisualStyleBackColor = true;
            // 
            // logTextbox
            // 
            logTextbox.Location = new Point(0, 0);
            logTextbox.Multiline = true;
            logTextbox.Name = "logTextbox";
            logTextbox.ReadOnly = true;
            logTextbox.ScrollBars = ScrollBars.Both;
            logTextbox.Size = new Size(434, 191);
            logTextbox.TabIndex = 0;
            logTextbox.WordWrap = false;
            logTextbox.TextChanged += logTextbox_TextChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnCancelarSucursal);
            tabPage1.Controls.Add(btnEliminarSucursal);
            tabPage1.Controls.Add(addedSucursalCombo);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btnAddSucursal);
            tabPage1.Controls.Add(sucursalNombreTextbox);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(sucursalIDTextbox);
            tabPage1.Controls.Add(label11);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(434, 191);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Sucursales";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancelarSucursal
            // 
            btnCancelarSucursal.Enabled = false;
            btnCancelarSucursal.Location = new Point(346, 69);
            btnCancelarSucursal.Name = "btnCancelarSucursal";
            btnCancelarSucursal.Size = new Size(75, 23);
            btnCancelarSucursal.TabIndex = 13;
            btnCancelarSucursal.Text = "Cancelar";
            btnCancelarSucursal.UseVisualStyleBackColor = true;
            btnCancelarSucursal.Click += btnCancelarSucursal_Click;
            // 
            // btnEliminarSucursal
            // 
            btnEliminarSucursal.Enabled = false;
            btnEliminarSucursal.Location = new Point(265, 69);
            btnEliminarSucursal.Name = "btnEliminarSucursal";
            btnEliminarSucursal.Size = new Size(75, 23);
            btnEliminarSucursal.TabIndex = 10;
            btnEliminarSucursal.Text = "Eliminar";
            btnEliminarSucursal.UseVisualStyleBackColor = true;
            btnEliminarSucursal.Click += btnEliminarSucursal_Click;
            // 
            // addedSucursalCombo
            // 
            addedSucursalCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            addedSucursalCombo.FormattingEnabled = true;
            addedSucursalCombo.Location = new Point(197, 98);
            addedSucursalCombo.Name = "addedSucursalCombo";
            addedSucursalCombo.Size = new Size(224, 23);
            addedSucursalCombo.TabIndex = 12;
            addedSucursalCombo.SelectedIndexChanged += addedSucursalCombo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 101);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 11;
            label1.Text = "Sucursales:";
            // 
            // btnAddSucursal
            // 
            btnAddSucursal.Location = new Point(183, 69);
            btnAddSucursal.Name = "btnAddSucursal";
            btnAddSucursal.Size = new Size(76, 23);
            btnAddSucursal.TabIndex = 10;
            btnAddSucursal.Text = "Añadir";
            btnAddSucursal.UseVisualStyleBackColor = true;
            btnAddSucursal.Click += btnAddSucursal_Click;
            // 
            // sucursalNombreTextbox
            // 
            sucursalNombreTextbox.Location = new Point(197, 40);
            sucursalNombreTextbox.Name = "sucursalNombreTextbox";
            sucursalNombreTextbox.Size = new Size(224, 23);
            sucursalNombreTextbox.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 41);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 8;
            label12.Text = "Nombre";
            // 
            // sucursalIDTextbox
            // 
            sucursalIDTextbox.Location = new Point(197, 10);
            sucursalIDTextbox.Name = "sucursalIDTextbox";
            sucursalIDTextbox.Size = new Size(224, 23);
            sucursalIDTextbox.TabIndex = 7;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 14);
            label11.Name = "label11";
            label11.Size = new Size(18, 15);
            label11.TabIndex = 6;
            label11.Text = "ID";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(375, 237);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // serialChangeTimer
            // 
            serialChangeTimer.Interval = 1000;
            serialChangeTimer.Tick += serialChangeTimer_Tick;
            // 
            // notify_options
            // 
            notify_options.Text = "notifyIcon1";
            notify_options.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 269);
            Controls.Add(btnAceptar);
            Controls.Add(tabProperties);
            Name = "Form1";
            Text = "Escaner SC500";
            FormClosing += Form1_FormClosing;
            tabProperties.ResumeLayout(false);
            tabPropertiesInside.ResumeLayout(false);
            tabPropertiesInside.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            logTab.ResumeLayout(false);
            logTab.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label portFoundLabel;
        private Button btnConectar;
        private Label textScanLabel;
        private Label label3;
        private Label textIdClienteLabel;
        private TabControl tabProperties;
        private TabPage tabPropertiesInside;
        private TabPage tabPage2;
        private TabPage logTab;
        private Label label4;
        private ComboBox sucursalSelect;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox sucursalAttrTextbox;
        private TextBox clienteAttrTextbox;
        private TextBox serviceURLTextbox;
        private Button btnAceptar;
        private TextBox serialTextbox;
        private TextBox vendorIdTextbox;
        private TextBox productIdTextbox;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox addedSucursalCombo;
        private Label serialStateLabel;
        private TabPage tabPage1;
        private TextBox sucursalNombreTextbox;
        private Label label12;
        private TextBox sucursalIDTextbox;
        private Label label11;
        private Button btnAddSucursal;
        private Button btnCancelarSucursal;
        private Button btnEliminarSucursal;
        private System.Windows.Forms.Timer serialChangeTimer;
        private TextBox logTextbox;
        private NotifyIcon notify_options;
        private TextBox deviceIdTextbox;
        private Label label14;
        private TextBox deviceAttrTextbox;
        private Label label13;
    }
}
