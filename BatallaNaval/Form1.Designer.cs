namespace BatallaNaval
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
            this.dgvJugador = new System.Windows.Forms.DataGridView();
            this.dgvEnemigo = new System.Windows.Forms.DataGridView();
            this.btnAgregarLancha = new System.Windows.Forms.Button();
            this.lblCoordeanadas = new System.Windows.Forms.Label();
            this.btnAtacar = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.btnDestructor = new System.Windows.Forms.Button();
            this.btnPortaviones = new System.Windows.Forms.Button();
            this.btnAcorazado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemigo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJugador
            // 
            this.dgvJugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugador.Location = new System.Drawing.Point(12, 152);
            this.dgvJugador.Name = "dgvJugador";
            this.dgvJugador.RowHeadersWidth = 51;
            this.dgvJugador.RowTemplate.Height = 24;
            this.dgvJugador.Size = new System.Drawing.Size(608, 371);
            this.dgvJugador.TabIndex = 0;
            // 
            // dgvEnemigo
            // 
            this.dgvEnemigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnemigo.Location = new System.Drawing.Point(626, 152);
            this.dgvEnemigo.Name = "dgvEnemigo";
            this.dgvEnemigo.RowHeadersWidth = 51;
            this.dgvEnemigo.RowTemplate.Height = 24;
            this.dgvEnemigo.Size = new System.Drawing.Size(614, 371);
            this.dgvEnemigo.TabIndex = 1;
            this.dgvEnemigo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnemigo_CellClick);
            // 
            // btnAgregarLancha
            // 
            this.btnAgregarLancha.Location = new System.Drawing.Point(461, 547);
            this.btnAgregarLancha.Name = "btnAgregarLancha";
            this.btnAgregarLancha.Size = new System.Drawing.Size(137, 44);
            this.btnAgregarLancha.TabIndex = 3;
            this.btnAgregarLancha.Text = "Agregar Lancha";
            this.btnAgregarLancha.UseVisualStyleBackColor = true;
            this.btnAgregarLancha.Click += new System.EventHandler(this.btnAgregarLancha_Click);
            // 
            // lblCoordeanadas
            // 
            this.lblCoordeanadas.AutoSize = true;
            this.lblCoordeanadas.Location = new System.Drawing.Point(623, 547);
            this.lblCoordeanadas.Name = "lblCoordeanadas";
            this.lblCoordeanadas.Size = new System.Drawing.Size(96, 16);
            this.lblCoordeanadas.TabIndex = 4;
            this.lblCoordeanadas.Text = "Coordenadas: ";
            // 
            // btnAtacar
            // 
            this.btnAtacar.Location = new System.Drawing.Point(872, 554);
            this.btnAtacar.Name = "btnAtacar";
            this.btnAtacar.Size = new System.Drawing.Size(170, 59);
            this.btnAtacar.TabIndex = 5;
            this.btnAtacar.Text = "Atacar";
            this.btnAtacar.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(499, 97);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(48, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "Turno: ";
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Location = new System.Drawing.Point(278, 612);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(89, 20);
            this.chkHorizontal.TabIndex = 8;
            this.chkHorizontal.Text = "Horizontal";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // btnDestructor
            // 
            this.btnDestructor.Location = new System.Drawing.Point(318, 547);
            this.btnDestructor.Name = "btnDestructor";
            this.btnDestructor.Size = new System.Drawing.Size(137, 44);
            this.btnDestructor.TabIndex = 9;
            this.btnDestructor.Text = "Agregar Destructor";
            this.btnDestructor.UseVisualStyleBackColor = true;
            this.btnDestructor.Click += new System.EventHandler(this.btnDestructor_Click);
            // 
            // btnPortaviones
            // 
            this.btnPortaviones.Location = new System.Drawing.Point(32, 547);
            this.btnPortaviones.Name = "btnPortaviones";
            this.btnPortaviones.Size = new System.Drawing.Size(137, 44);
            this.btnPortaviones.TabIndex = 10;
            this.btnPortaviones.Text = "Agregar Portaviones";
            this.btnPortaviones.UseVisualStyleBackColor = true;
            this.btnPortaviones.Click += new System.EventHandler(this.btnPortaviones_Click);
            // 
            // btnAcorazado
            // 
            this.btnAcorazado.Location = new System.Drawing.Point(175, 547);
            this.btnAcorazado.Name = "btnAcorazado";
            this.btnAcorazado.Size = new System.Drawing.Size(137, 44);
            this.btnAcorazado.TabIndex = 11;
            this.btnAcorazado.Text = "Agregar Acorazado";
            this.btnAcorazado.UseVisualStyleBackColor = true;
            this.btnAcorazado.Click += new System.EventHandler(this.btnAcorazado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(18, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1211, 69);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(78, 34);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(216, 22);
            this.txtIP.TabIndex = 0;
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(406, 34);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(216, 22);
            this.txtPuerto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puerto:";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(669, 20);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(130, 43);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAcorazado);
            this.Controls.Add(this.btnPortaviones);
            this.Controls.Add(this.btnDestructor);
            this.Controls.Add(this.chkHorizontal);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.lblCoordeanadas);
            this.Controls.Add(this.btnAgregarLancha);
            this.Controls.Add(this.dgvEnemigo);
            this.Controls.Add(this.dgvJugador);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemigo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJugador;
        private System.Windows.Forms.DataGridView dgvEnemigo;
        private System.Windows.Forms.Button btnAgregarLancha;
        private System.Windows.Forms.Label lblCoordeanadas;
        private System.Windows.Forms.Button btnAtacar;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.CheckBox chkHorizontal;
        private System.Windows.Forms.Button btnDestructor;
        private System.Windows.Forms.Button btnPortaviones;
        private System.Windows.Forms.Button btnAcorazado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConectar;
    }
}

