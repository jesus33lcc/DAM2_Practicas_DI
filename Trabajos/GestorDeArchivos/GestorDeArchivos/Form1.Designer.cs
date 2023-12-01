namespace GestorDeArchivos
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
            rtbTextArea = new RichTextBox();
            menuStrip1 = new MenuStrip();
            tsmiInfo = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tsmiGuardar = new ToolStripMenuItem();
            tsmiBorrar = new ToolStripMenuItem();
            tsmiAbrir = new ToolStripMenuItem();
            tsmiNewFile = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // rtbTextArea
            // 
            rtbTextArea.Dock = DockStyle.Fill;
            rtbTextArea.Location = new Point(0, 24);
            rtbTextArea.Name = "rtbTextArea";
            rtbTextArea.Size = new Size(443, 359);
            rtbTextArea.TabIndex = 0;
            rtbTextArea.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiInfo, fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(443, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmiInfo
            // 
            tsmiInfo.Name = "tsmiInfo";
            tsmiInfo.Size = new Size(40, 20);
            tsmiInfo.Text = "Info";
            tsmiInfo.Click += tsmiInfo_Click;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiGuardar, tsmiBorrar, tsmiAbrir, tsmiNewFile });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmiGuardar
            // 
            tsmiGuardar.Name = "tsmiGuardar";
            tsmiGuardar.Size = new Size(180, 22);
            tsmiGuardar.Text = "Guardar";
            tsmiGuardar.Click += tsmiGuardar_Click;
            // 
            // tsmiBorrar
            // 
            tsmiBorrar.Name = "tsmiBorrar";
            tsmiBorrar.Size = new Size(180, 22);
            tsmiBorrar.Text = "Borrar";
            tsmiBorrar.Click += tsmiBorrar_Click;
            // 
            // tsmiAbrir
            // 
            tsmiAbrir.Name = "tsmiAbrir";
            tsmiAbrir.Size = new Size(180, 22);
            tsmiAbrir.Text = "Abrir";
            tsmiAbrir.Click += tsmiAbrir_Click;
            // 
            // tsmiNewFile
            // 
            tsmiNewFile.Name = "tsmiNewFile";
            tsmiNewFile.Size = new Size(180, 22);
            tsmiNewFile.Text = "New File";
            tsmiNewFile.Click += tsmiNewFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 383);
            Controls.Add(rtbTextArea);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Gestor Archivos";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbTextArea;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiInfo;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem tsmiGuardar;
        private ToolStripMenuItem tsmiBorrar;
        private ToolStripMenuItem tsmiAbrir;
        private ToolStripMenuItem tsmiNewFile;
    }
}