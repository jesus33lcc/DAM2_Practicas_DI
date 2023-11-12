namespace GestorDeArchivos.Ventanas
{
    partial class FormInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            pbImagen = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(0, 210);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(444, 96);
            richTextBox1.TabIndex = 2;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "Esta aplicacion ha sido realizada por Jesús Luis Condori Chambi, esta diseñada para permitir crear, modificar y borrar archivos.";
            // 
            // panel1
            // 
            panel1.Controls.Add(pbImagen);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 210);
            panel1.TabIndex = 3;
            // 
            // pbImagen
            // 
            pbImagen.Dock = DockStyle.Fill;
            pbImagen.Location = new Point(0, 0);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(444, 210);
            pbImagen.TabIndex = 0;
            pbImagen.TabStop = false;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 306);
            Controls.Add(panel1);
            Controls.Add(richTextBox1);
            Name = "FormInfo";
            Text = "Info";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBox1;
        private Panel panel1;
        private PictureBox pbImagen;
    }
}