namespace CambioDivisa
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
            panelBotones = new Panel();
            lstBoxHistorico = new ListBox();
            btnDobleFlecha = new Button();
            btnCambiar = new Button();
            cmbBoxA = new ComboBox();
            cmbBoxDe = new ComboBox();
            txtBImporte = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(lstBoxHistorico);
            panelBotones.Controls.Add(btnDobleFlecha);
            panelBotones.Controls.Add(btnCambiar);
            panelBotones.Controls.Add(cmbBoxA);
            panelBotones.Controls.Add(cmbBoxDe);
            panelBotones.Controls.Add(txtBImporte);
            panelBotones.Controls.Add(label3);
            panelBotones.Controls.Add(label2);
            panelBotones.Controls.Add(label1);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.Location = new Point(0, 0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(455, 324);
            panelBotones.TabIndex = 1;
            // 
            // lstBoxHistorico
            // 
            lstBoxHistorico.Dock = DockStyle.Bottom;
            lstBoxHistorico.FormattingEnabled = true;
            lstBoxHistorico.ItemHeight = 15;
            lstBoxHistorico.Location = new Point(0, 170);
            lstBoxHistorico.Name = "lstBoxHistorico";
            lstBoxHistorico.Size = new Size(455, 154);
            lstBoxHistorico.TabIndex = 7;
            // 
            // btnDobleFlecha
            // 
            btnDobleFlecha.Image = Properties.Resources.flecha;
            btnDobleFlecha.Location = new Point(240, 51);
            btnDobleFlecha.Name = "btnDobleFlecha";
            btnDobleFlecha.Size = new Size(84, 31);
            btnDobleFlecha.TabIndex = 6;
            btnDobleFlecha.Text = "DF";
            btnDobleFlecha.UseVisualStyleBackColor = true;
            btnDobleFlecha.Click += btnDobleFlecha_Click;
            // 
            // btnCambiar
            // 
            btnCambiar.Enabled = false;
            btnCambiar.Location = new Point(330, 102);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(100, 44);
            btnCambiar.TabIndex = 5;
            btnCambiar.Text = "Cambiar";
            btnCambiar.UseVisualStyleBackColor = true;
            btnCambiar.Click += btnCambiar_Click;
            // 
            // cmbBoxA
            // 
            cmbBoxA.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxA.FormattingEnabled = true;
            cmbBoxA.Items.AddRange(new object[] { "Euros", "Libras", "Dollars" });
            cmbBoxA.Location = new Point(330, 56);
            cmbBoxA.Name = "cmbBoxA";
            cmbBoxA.Size = new Size(100, 23);
            cmbBoxA.TabIndex = 4;
            // 
            // cmbBoxDe
            // 
            cmbBoxDe.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDe.FormattingEnabled = true;
            cmbBoxDe.Items.AddRange(new object[] { "Euros", "Libras", "Dollars" });
            cmbBoxDe.Location = new Point(130, 56);
            cmbBoxDe.Name = "cmbBoxDe";
            cmbBoxDe.Size = new Size(100, 23);
            cmbBoxDe.TabIndex = 3;
            // 
            // txtBImporte
            // 
            txtBImporte.Location = new Point(12, 56);
            txtBImporte.Name = "txtBImporte";
            txtBImporte.Size = new Size(112, 23);
            txtBImporte.TabIndex = 0;
            txtBImporte.KeyPress += txtBImporte_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(360, 23);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 2;
            label3.Text = "a:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 23);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 1;
            label2.Text = "De:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 23);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Importe:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 324);
            Controls.Add(panelBotones);
            Name = "Form1";
            Text = "Form1";
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelBotones;
        private TextBox txtBImporte;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDobleFlecha;
        private Button btnCambiar;
        private ComboBox cmbBoxA;
        private ComboBox cmbBoxDe;
        private ListBox lstBoxHistorico;
    }
}