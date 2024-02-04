using System.Drawing;
using System.Windows.Forms;

namespace Trabajo2aEvaluacionDI.Vistas
{
    partial class UCBaseDeDatos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.btnRenovar = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnNuevoJugador = new System.Windows.Forms.Button();
            this.txtBoxValor = new System.Windows.Forms.TextBox();
            this.txtBoxPais = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtboxClub = new System.Windows.Forms.TextBox();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblClub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnBuscar.Location = new System.Drawing.Point(480, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 43);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblTitulo.Location = new System.Drawing.Point(8, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(151, 45);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "BDFutbol";
            // 
            // panelDatos
            // 
            this.panelDatos.Location = new System.Drawing.Point(480, 86);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(120, 200);
            this.panelDatos.TabIndex = 10;
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Location = new System.Drawing.Point(16, 86);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowTemplate.Height = 25;
            this.dgvTabla.Size = new System.Drawing.Size(458, 258);
            this.dgvTabla.TabIndex = 11;
            this.dgvTabla.SelectionChanged += new System.EventHandler(this.dgvTabla_SelectionChanged);
            // 
            // btnRenovar
            // 
            this.btnRenovar.Location = new System.Drawing.Point(480, 292);
            this.btnRenovar.Name = "btnRenovar";
            this.btnRenovar.Size = new System.Drawing.Size(120, 23);
            this.btnRenovar.TabIndex = 12;
            this.btnRenovar.Text = "Renovar";
            this.btnRenovar.UseVisualStyleBackColor = true;
            this.btnRenovar.Click += new System.EventHandler(this.btnRenovar_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(480, 321);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(120, 23);
            this.btnVender.TabIndex = 13;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnNuevoJugador
            // 
            this.btnNuevoJugador.Location = new System.Drawing.Point(16, 59);
            this.btnNuevoJugador.Name = "btnNuevoJugador";
            this.btnNuevoJugador.Size = new System.Drawing.Size(143, 23);
            this.btnNuevoJugador.TabIndex = 14;
            this.btnNuevoJugador.Text = "Comprar Jugador";
            this.btnNuevoJugador.UseVisualStyleBackColor = true;
            this.btnNuevoJugador.Click += new System.EventHandler(this.btnNuevoJugador_Click);
            // 
            // txtBoxValor
            // 
            this.txtBoxValor.Location = new System.Drawing.Point(374, 59);
            this.txtBoxValor.Name = "txtBoxValor";
            this.txtBoxValor.Size = new System.Drawing.Size(100, 20);
            this.txtBoxValor.TabIndex = 15;
            this.txtBoxValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            this.txtBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxValor_KeyPress);
            // 
            // txtBoxPais
            // 
            this.txtBoxPais.Location = new System.Drawing.Point(374, 36);
            this.txtBoxPais.Name = "txtBoxPais";
            this.txtBoxPais.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPais.TabIndex = 16;
            this.txtBoxPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(334, 39);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(30, 13);
            this.lblPais.TabIndex = 17;
            this.lblPais.Text = "Pais:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(334, 62);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 18;
            this.lblValor.Text = "Valor:";
            // 
            // txtboxClub
            // 
            this.txtboxClub.Location = new System.Drawing.Point(228, 59);
            this.txtboxClub.Name = "txtboxClub";
            this.txtboxClub.Size = new System.Drawing.Size(100, 20);
            this.txtboxClub.TabIndex = 19;
            this.txtboxClub.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(228, 36);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNombre.TabIndex = 20;
            this.txtBoxNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(171, 39);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 21;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.Location = new System.Drawing.Point(171, 62);
            this.lblClub.Name = "lblClub";
            this.lblClub.Size = new System.Drawing.Size(31, 13);
            this.lblClub.TabIndex = 22;
            this.lblClub.Text = "Club:";
            // 
            // UCBaseDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lblClub);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.txtboxClub);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.txtBoxPais);
            this.Controls.Add(this.txtBoxValor);
            this.Controls.Add(this.btnNuevoJugador);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnRenovar);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnBuscar);
            this.Name = "UCBaseDeDatos";
            this.Size = new System.Drawing.Size(607, 379);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Button btnBuscar;
        private Label lblTitulo;
        private Panel panelDatos;
        public DataGridView dgvTabla;
        private Button btnRenovar;
        private Button btnVender;
        private Button btnNuevoJugador;
        private TextBox txtBoxValor;
        private TextBox txtBoxPais;
        private Label lblPais;
        private Label lblValor;
        private TextBox txtboxClub;
        private TextBox txtBoxNombre;
        private Label lblNombre;
        private Label lblClub;
    }
}
