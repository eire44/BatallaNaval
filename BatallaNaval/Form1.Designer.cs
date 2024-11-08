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
            this.components = new System.ComponentModel.Container();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.tiempoTerminar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemigo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJugador
            // 
            this.dgvJugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugador.Location = new System.Drawing.Point(12, 153);
            this.dgvJugador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvJugador.Name = "dgvJugador";
            this.dgvJugador.RowHeadersWidth = 51;
            this.dgvJugador.RowTemplate.Height = 24;
            this.dgvJugador.Size = new System.Drawing.Size(608, 370);
            this.dgvJugador.TabIndex = 0;
            // 
            // dgvEnemigo
            // 
            this.dgvEnemigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnemigo.Location = new System.Drawing.Point(627, 153);
            this.dgvEnemigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEnemigo.Name = "dgvEnemigo";
            this.dgvEnemigo.RowHeadersWidth = 51;
            this.dgvEnemigo.RowTemplate.Height = 24;
            this.dgvEnemigo.Size = new System.Drawing.Size(613, 370);
            this.dgvEnemigo.TabIndex = 1;
            this.dgvEnemigo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnemigo_CellClick);
            // 
            // btnAgregarLancha
            // 
            this.btnAgregarLancha.Location = new System.Drawing.Point(461, 546);
            this.btnAgregarLancha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.lblCoordeanadas.Location = new System.Drawing.Point(623, 546);
            this.lblCoordeanadas.Name = "lblCoordeanadas";
            this.lblCoordeanadas.Size = new System.Drawing.Size(96, 16);
            this.lblCoordeanadas.TabIndex = 4;
            this.lblCoordeanadas.Text = "Coordenadas: ";
            // 
            // btnAtacar
            // 
            this.btnAtacar.Location = new System.Drawing.Point(872, 554);
            this.btnAtacar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtacar.Name = "btnAtacar";
            this.btnAtacar.Size = new System.Drawing.Size(171, 59);
            this.btnAtacar.TabIndex = 5;
            this.btnAtacar.Text = "Atacar";
            this.btnAtacar.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(912, 62);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(48, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "Turno: ";
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Location = new System.Drawing.Point(277, 612);
            this.chkHorizontal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(89, 20);
            this.chkHorizontal.TabIndex = 8;
            this.chkHorizontal.Text = "Horizontal";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // btnDestructor
            // 
            this.btnDestructor.Location = new System.Drawing.Point(317, 546);
            this.btnDestructor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDestructor.Name = "btnDestructor";
            this.btnDestructor.Size = new System.Drawing.Size(137, 44);
            this.btnDestructor.TabIndex = 9;
            this.btnDestructor.Text = "Agregar Destructor";
            this.btnDestructor.UseVisualStyleBackColor = true;
            this.btnDestructor.Click += new System.EventHandler(this.btnDestructor_Click);
            // 
            // btnPortaviones
            // 
            this.btnPortaviones.Location = new System.Drawing.Point(32, 546);
            this.btnPortaviones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPortaviones.Name = "btnPortaviones";
            this.btnPortaviones.Size = new System.Drawing.Size(137, 44);
            this.btnPortaviones.TabIndex = 10;
            this.btnPortaviones.Text = "Agregar Portaviones";
            this.btnPortaviones.UseVisualStyleBackColor = true;
            this.btnPortaviones.Click += new System.EventHandler(this.btnPortaviones_Click);
            // 
            // btnAcorazado
            // 
            this.btnAcorazado.Location = new System.Drawing.Point(175, 546);
            this.btnAcorazado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcorazado.Name = "btnAcorazado";
            this.btnAcorazado.Size = new System.Drawing.Size(137, 44);
            this.btnAcorazado.TabIndex = 11;
            this.btnAcorazado.Text = "Agregar Acorazado";
            this.btnAcorazado.UseVisualStyleBackColor = true;
            this.btnAcorazado.Click += new System.EventHandler(this.btnAcorazado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(19, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(617, 69);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión al Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puerto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(385, 33);
            this.txtPuerto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(216, 22);
            this.txtPuerto.TabIndex = 1;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(57, 33);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(216, 22);
            this.txtIP.TabIndex = 0;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(244, 649);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(154, 51);
            this.btnTerminar.TabIndex = 13;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // tiempoTerminar
            // 
            this.tiempoTerminar.Enabled = true;
            this.tiempoTerminar.Interval = 1000;
            this.tiempoTerminar.Tick += new System.EventHandler(this.tiempoTerminar_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 712);
            this.Controls.Add(this.btnTerminar);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Timer tiempoTerminar;
    }
}

