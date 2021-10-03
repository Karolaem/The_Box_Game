namespace Intento_de_Videojuego
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Cronometro = new System.Windows.Forms.Timer(this.components);
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.lblExplicacion = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnTitleScreen = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.PanelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cronometro
            // 
            this.Cronometro.Enabled = true;
            this.Cronometro.Interval = 30;
            this.Cronometro.Tick += new System.EventHandler(this.Cronometro_Tick);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelPrincipal.Controls.Add(this.lblExplicacion);
            this.PanelPrincipal.Controls.Add(this.lblNivel);
            this.PanelPrincipal.Controls.Add(this.btnCerrar);
            this.PanelPrincipal.Controls.Add(this.btnTitleScreen);
            this.PanelPrincipal.Controls.Add(this.btnReset);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(140, 444);
            this.PanelPrincipal.TabIndex = 3;
            // 
            // lblExplicacion
            // 
            this.lblExplicacion.AutoSize = true;
            this.lblExplicacion.Location = new System.Drawing.Point(25, 367);
            this.lblExplicacion.Name = "lblExplicacion";
            this.lblExplicacion.Size = new System.Drawing.Size(89, 68);
            this.lblExplicacion.TabIndex = 5;
            this.lblExplicacion.Text = "Controles:\r\nIzquierda (A)\r\nDerecha (D)\r\nSalto (W)";
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(23, 9);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(95, 17);
            this.lblNivel.TabIndex = 5;
            this.lblNivel.Text = "Nivel 1 de 3";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(5, 285);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(130, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Salir";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnTitleScreen
            // 
            this.btnTitleScreen.Location = new System.Drawing.Point(5, 247);
            this.btnTitleScreen.Name = "btnTitleScreen";
            this.btnTitleScreen.Size = new System.Drawing.Size(130, 23);
            this.btnTitleScreen.TabIndex = 4;
            this.btnTitleScreen.Text = "Pantalla Principal";
            this.btnTitleScreen.UseVisualStyleBackColor = true;
            this.btnTitleScreen.Click += new System.EventHandler(this.btnTitleScreen_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(5, 209);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reiniciar nivel";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.SystemColors.Control;
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(140, 0);
            this.PanelContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(639, 444);
            this.PanelContenedor.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(779, 444);
            this.ControlBox = false;
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.PanelPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Box Game";
            this.Activated += new System.EventHandler(this.FormPrincipal_Activated);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Cronometro;
        private System.Windows.Forms.Panel PanelPrincipal;
        public System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnTitleScreen;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblExplicacion;
        private System.Windows.Forms.Label lblNivel;
    }
}

