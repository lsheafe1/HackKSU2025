namespace HackKSU2025
{
    partial class MainForm
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
            uxPanelContainer = new Panel();
            menuPage1 = new MenuPage();
            uxPanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // uxPanelContainer
            // 
            uxPanelContainer.Controls.Add(menuPage1);
            uxPanelContainer.Dock = DockStyle.Fill;
            uxPanelContainer.Location = new Point(0, 0);
            uxPanelContainer.Name = "uxPanelContainer";
            uxPanelContainer.Size = new Size(1024, 768);
            uxPanelContainer.TabIndex = 0;
            // 
            // menuPage1
            // 
            menuPage1.BackColor = Color.AntiqueWhite;
            menuPage1.Dock = DockStyle.Fill;
            menuPage1.Location = new Point(0, 0);
            menuPage1.Name = "menuPage1";
            menuPage1.Size = new Size(1024, 768);
            menuPage1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1024, 768);
            Controls.Add(uxPanelContainer);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "SafeSpeech";
            uxPanelContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel uxPanelContainer;
        private MenuPage menuPage1;
    }
}
