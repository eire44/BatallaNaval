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
            this.btnAgregarBarco = new System.Windows.Forms.Button();
            this.lblCoordeanadas = new System.Windows.Forms.Label();
            this.btnAtacar = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblBarcoAAgregar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemigo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJugador
            // 
            this.dgvJugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugador.Location = new System.Drawing.Point(7, 71);
            this.dgvJugador.Name = "dgvJugador";
            this.dgvJugador.RowHeadersWidth = 51;
            this.dgvJugador.RowTemplate.Height = 24;
            this.dgvJugador.Size = new System.Drawing.Size(608, 394);
            this.dgvJugador.TabIndex = 0;
            // 
            // dgvEnemigo
            // 
            this.dgvEnemigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnemigo.Location = new System.Drawing.Point(621, 71);
            this.dgvEnemigo.Name = "dgvEnemigo";
            this.dgvEnemigo.RowHeadersWidth = 51;
            this.dgvEnemigo.RowTemplate.Height = 24;
            this.dgvEnemigo.Size = new System.Drawing.Size(702, 395);
            this.dgvEnemigo.TabIndex = 1;
            // 
            // btnAgregarBarco
            // 
            this.btnAgregarBarco.Location = new System.Drawing.Point(340, 491);
            this.btnAgregarBarco.Name = "btnAgregarBarco";
            this.btnAgregarBarco.Size = new System.Drawing.Size(159, 59);
            this.btnAgregarBarco.TabIndex = 3;
            this.btnAgregarBarco.Text = "Agregar Barco";
            this.btnAgregarBarco.UseVisualStyleBackColor = true;
            // 
            // lblCoordeanadas
            // 
            this.lblCoordeanadas.AutoSize = true;
            this.lblCoordeanadas.Location = new System.Drawing.Point(568, 493);
            this.lblCoordeanadas.Name = "lblCoordeanadas";
            this.lblCoordeanadas.Size = new System.Drawing.Size(96, 16);
            this.lblCoordeanadas.TabIndex = 4;
            this.lblCoordeanadas.Text = "Coordenadas: ";
            // 
            // btnAtacar
            // 
            this.btnAtacar.Location = new System.Drawing.Point(760, 491);
            this.btnAtacar.Name = "btnAtacar";
            this.btnAtacar.Size = new System.Drawing.Size(170, 59);
            this.btnAtacar.TabIndex = 5;
            this.btnAtacar.Text = "Atacar";
            this.btnAtacar.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(494, 16);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(48, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "Turno: ";
            // 
            // lblBarcoAAgregar
            // 
            this.lblBarcoAAgregar.AutoSize = true;
            this.lblBarcoAAgregar.Location = new System.Drawing.Point(47, 506);
            this.lblBarcoAAgregar.Name = "lblBarcoAAgregar";
            this.lblBarcoAAgregar.Size = new System.Drawing.Size(62, 16);
            this.lblBarcoAAgregar.TabIndex = 7;
            this.lblBarcoAAgregar.Text = "Agregar: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 571);
            this.Controls.Add(this.lblBarcoAAgregar);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.lblCoordeanadas);
            this.Controls.Add(this.btnAgregarBarco);
            this.Controls.Add(this.dgvEnemigo);
            this.Controls.Add(this.dgvJugador);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnemigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJugador;
        private System.Windows.Forms.DataGridView dgvEnemigo;
        private System.Windows.Forms.Button btnAgregarBarco;
        private System.Windows.Forms.Label lblCoordeanadas;
        private System.Windows.Forms.Button btnAtacar;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblBarcoAAgregar;
    }
}

