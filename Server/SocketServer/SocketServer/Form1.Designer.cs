namespace SocketServer
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEscuchar = new System.Windows.Forms.Button();
            this.cmbIPs = new System.Windows.Forms.ComboBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPs Locales:";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(265, 63);
            this.txtPuerto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(153, 22);
            this.txtPuerto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto:";
            // 
            // btnEscuchar
            // 
            this.btnEscuchar.Location = new System.Drawing.Point(461, 38);
            this.btnEscuchar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEscuchar.Name = "btnEscuchar";
            this.btnEscuchar.Size = new System.Drawing.Size(117, 46);
            this.btnEscuchar.TabIndex = 4;
            this.btnEscuchar.Text = "Escuchar";
            this.btnEscuchar.UseVisualStyleBackColor = true;
            this.btnEscuchar.Click += new System.EventHandler(this.btnEscuchar_Click);
            // 
            // cmbIPs
            // 
            this.cmbIPs.FormattingEnabled = true;
            this.cmbIPs.Location = new System.Drawing.Point(45, 62);
            this.cmbIPs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbIPs.Name = "cmbIPs";
            this.cmbIPs.Size = new System.Drawing.Size(187, 24);
            this.cmbIPs.TabIndex = 5;
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(621, 38);
            this.btnDetener.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(117, 46);
            this.btnDetener.TabIndex = 6;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // txtDatos
            // 
            this.txtDatos.Location = new System.Drawing.Point(51, 122);
            this.txtDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatos.Multiline = true;
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.Size = new System.Drawing.Size(688, 299);
            this.txtDatos.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.cmbIPs);
            this.Controls.Add(this.btnEscuchar);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEscuchar;
        private System.Windows.Forms.ComboBox cmbIPs;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.TextBox txtDatos;
    }
}

