namespace HackKSU2025
{
    partial class MenuPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uxMenuPanel = new Panel();
            uxTip = new Label();
            uxTitle = new Label();
            uxButtonContainer = new FlowLayoutPanel();
            uxStartParent = new Button();
            uxStartTeacher = new Button();
            uxMenuPanel.SuspendLayout();
            uxButtonContainer.SuspendLayout();
            SuspendLayout();
            // 
            // uxMenuPanel
            // 
            uxMenuPanel.Controls.Add(uxTip);
            uxMenuPanel.Controls.Add(uxTitle);
            uxMenuPanel.Controls.Add(uxButtonContainer);
            uxMenuPanel.Dock = DockStyle.Fill;
            uxMenuPanel.Location = new Point(0, 0);
            uxMenuPanel.Name = "uxMenuPanel";
            uxMenuPanel.Size = new Size(1024, 768);
            uxMenuPanel.TabIndex = 2;
            // 
            // uxTip
            // 
            uxTip.AutoSize = true;
            uxTip.Font = new Font("Power Calm", 21.7499962F, FontStyle.Italic, GraphicsUnit.Point, 0);
            uxTip.ForeColor = Color.SlateGray;
            uxTip.Location = new Point(350, 325);
            uxTip.Name = "uxTip";
            uxTip.Size = new Size(325, 35);
            uxTip.TabIndex = 3;
            uxTip.Text = "Select a mode to begin";
            // 
            // uxTitle
            // 
            uxTitle.AutoSize = true;
            uxTitle.Font = new Font("Power Calm", 71.99999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uxTitle.ForeColor = Color.CadetBlue;
            uxTitle.Location = new Point(222, 134);
            uxTitle.Name = "uxTitle";
            uxTitle.Size = new Size(611, 116);
            uxTitle.TabIndex = 2;
            uxTitle.Text = "SafeSpeech";
            uxTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uxButtonContainer
            // 
            uxButtonContainer.AutoSize = true;
            uxButtonContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxButtonContainer.Controls.Add(uxStartParent);
            uxButtonContainer.Controls.Add(uxStartTeacher);
            uxButtonContainer.Location = new Point(133, 360);
            uxButtonContainer.Margin = new Padding(3, 100, 3, 3);
            uxButtonContainer.Name = "uxButtonContainer";
            uxButtonContainer.Size = new Size(786, 272);
            uxButtonContainer.TabIndex = 1;
            // 
            // uxStartParent
            // 
            uxStartParent.AutoSize = true;
            uxStartParent.BackColor = Color.CadetBlue;
            uxStartParent.Cursor = Cursors.Hand;
            uxStartParent.Dock = DockStyle.Fill;
            uxStartParent.FlatStyle = FlatStyle.Flat;
            uxStartParent.Font = new Font("Power Calm", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxStartParent.ForeColor = Color.Azure;
            uxStartParent.Location = new Point(50, 50);
            uxStartParent.Margin = new Padding(50);
            uxStartParent.Name = "uxStartParent";
            uxStartParent.Size = new Size(318, 172);
            uxStartParent.TabIndex = 0;
            uxStartParent.Text = "Parent";
            uxStartParent.UseVisualStyleBackColor = false;
            uxStartParent.Click += uxParentClick;
            // 
            // uxStartTeacher
            // 
            uxStartTeacher.AutoSize = true;
            uxStartTeacher.BackColor = Color.CadetBlue;
            uxStartTeacher.Cursor = Cursors.Hand;
            uxStartTeacher.Dock = DockStyle.Fill;
            uxStartTeacher.FlatStyle = FlatStyle.Flat;
            uxStartTeacher.Font = new Font("Power Calm", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxStartTeacher.ForeColor = Color.Azure;
            uxStartTeacher.Location = new Point(418, 50);
            uxStartTeacher.Margin = new Padding(0, 50, 50, 50);
            uxStartTeacher.Name = "uxStartTeacher";
            uxStartTeacher.Size = new Size(318, 172);
            uxStartTeacher.TabIndex = 1;
            uxStartTeacher.Text = "Teacher";
            uxStartTeacher.UseVisualStyleBackColor = false;
            uxStartTeacher.Click += uxTeacherClick;
            // 
            // MenuPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(uxMenuPanel);
            Name = "MenuPage";
            Size = new Size(1024, 768);
            uxMenuPanel.ResumeLayout(false);
            uxMenuPanel.PerformLayout();
            uxButtonContainer.ResumeLayout(false);
            uxButtonContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel uxMenuPanel;
        private FlowLayoutPanel uxButtonContainer;
        private Button uxStartParent;
        private Label uxTitle;
        private Button uxStartTeacher;
        private Label uxTip;
    }
}
