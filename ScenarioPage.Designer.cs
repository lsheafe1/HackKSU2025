namespace HackKSU2025
{
    partial class ScenarioPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenarioPage));
            uxButtonContainer = new FlowLayoutPanel();
            uxBack = new Button();
            uxNew = new Button();
            uxMessageBox = new RichTextBox();
            uxScenarioContainer = new Panel();
            uxRecordButton = new Button();
            uxSpinner = new PictureBox();
            uxSendButton = new Button();
            uxUserText = new TextBox();
            uxButtonContainer.SuspendLayout();
            uxScenarioContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxSpinner).BeginInit();
            SuspendLayout();
            // 
            // uxButtonContainer
            // 
            uxButtonContainer.AutoSize = true;
            uxButtonContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxButtonContainer.Controls.Add(uxBack);
            uxButtonContainer.Controls.Add(uxNew);
            uxButtonContainer.Location = new Point(22, 14);
            uxButtonContainer.Margin = new Padding(3, 100, 3, 3);
            uxButtonContainer.Name = "uxButtonContainer";
            uxButtonContainer.Size = new Size(224, 65);
            uxButtonContainer.TabIndex = 2;
            // 
            // uxBack
            // 
            uxBack.AutoSize = true;
            uxBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxBack.BackColor = Color.CadetBlue;
            uxBack.Cursor = Cursors.Hand;
            uxBack.FlatStyle = FlatStyle.Flat;
            uxBack.Font = new Font("Microsoft Sans Serif", 21.7499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxBack.ForeColor = Color.Azure;
            uxBack.Location = new Point(10, 10);
            uxBack.Margin = new Padding(10);
            uxBack.Name = "uxBack";
            uxBack.Size = new Size(99, 45);
            uxBack.TabIndex = 0;
            uxBack.Text = "Menu";
            uxBack.UseVisualStyleBackColor = false;
            uxBack.Click += uxBackClick;
            // 
            // uxNew
            // 
            uxNew.AutoSize = true;
            uxNew.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxNew.BackColor = Color.CadetBlue;
            uxNew.Cursor = Cursors.Hand;
            uxNew.FlatStyle = FlatStyle.Flat;
            uxNew.Font = new Font("Microsoft Sans Serif", 21.7499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxNew.ForeColor = Color.Azure;
            uxNew.Location = new Point(129, 10);
            uxNew.Margin = new Padding(10);
            uxNew.Name = "uxNew";
            uxNew.Size = new Size(85, 45);
            uxNew.TabIndex = 1;
            uxNew.Text = "New";
            uxNew.UseVisualStyleBackColor = false;
            uxNew.Click += uxNewClick;
            // 
            // uxMessageBox
            // 
            uxMessageBox.BackColor = Color.Linen;
            uxMessageBox.BorderStyle = BorderStyle.FixedSingle;
            uxMessageBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxMessageBox.Location = new Point(20, 102);
            uxMessageBox.Name = "uxMessageBox";
            uxMessageBox.ReadOnly = true;
            uxMessageBox.Size = new Size(985, 473);
            uxMessageBox.TabIndex = 3;
            uxMessageBox.Text = "";
            uxMessageBox.MouseMove += uxMouseMove;
            // 
            // uxScenarioContainer
            // 
            uxScenarioContainer.Controls.Add(uxRecordButton);
            uxScenarioContainer.Controls.Add(uxSpinner);
            uxScenarioContainer.Controls.Add(uxSendButton);
            uxScenarioContainer.Controls.Add(uxUserText);
            uxScenarioContainer.Controls.Add(uxButtonContainer);
            uxScenarioContainer.Controls.Add(uxMessageBox);
            uxScenarioContainer.Dock = DockStyle.Fill;
            uxScenarioContainer.Location = new Point(0, 0);
            uxScenarioContainer.Name = "uxScenarioContainer";
            uxScenarioContainer.Size = new Size(1024, 768);
            uxScenarioContainer.TabIndex = 4;
            // 
            // uxRecordButton
            // 
            uxRecordButton.BackColor = Color.White;
            uxRecordButton.BackgroundImage = (Image)resources.GetObject("uxRecordButton.BackgroundImage");
            uxRecordButton.BackgroundImageLayout = ImageLayout.Stretch;
            uxRecordButton.Location = new Point(842, 581);
            uxRecordButton.Name = "uxRecordButton";
            uxRecordButton.Size = new Size(80, 80);
            uxRecordButton.TabIndex = 7;
            uxRecordButton.UseVisualStyleBackColor = false;
            uxRecordButton.Click += uxRecordClick;
            // 
            // uxSpinner
            // 
            uxSpinner.BackColor = Color.Transparent;
            uxSpinner.Image = (Image)resources.GetObject("uxSpinner.Image");
            uxSpinner.Location = new Point(22, 581);
            uxSpinner.Name = "uxSpinner";
            uxSpinner.Size = new Size(54, 69);
            uxSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            uxSpinner.TabIndex = 6;
            uxSpinner.TabStop = false;
            // 
            // uxSendButton
            // 
            uxSendButton.BackgroundImage = (Image)resources.GetObject("uxSendButton.BackgroundImage");
            uxSendButton.BackgroundImageLayout = ImageLayout.Stretch;
            uxSendButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uxSendButton.Location = new Point(922, 581);
            uxSendButton.Name = "uxSendButton";
            uxSendButton.Size = new Size(80, 80);
            uxSendButton.TabIndex = 5;
            uxSendButton.UseVisualStyleBackColor = true;
            uxSendButton.Click += uxSendClick;
            // 
            // uxUserText
            // 
            uxUserText.Location = new Point(442, 581);
            uxUserText.Multiline = true;
            uxUserText.Name = "uxUserText";
            uxUserText.Size = new Size(400, 80);
            uxUserText.TabIndex = 4;
            uxUserText.KeyDown += uxSendEnter;
            // 
            // ScenarioPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(uxScenarioContainer);
            Name = "ScenarioPage";
            Size = new Size(1024, 768);
            Load += ScenarioPageLoad;
            uxButtonContainer.ResumeLayout(false);
            uxButtonContainer.PerformLayout();
            uxScenarioContainer.ResumeLayout(false);
            uxScenarioContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uxSpinner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel uxButtonContainer;
        private Button uxBack;
        private Button uxNew;
        private RichTextBox uxMessageBox;
        private Panel uxScenarioContainer;
        private Button uxSendButton;
        private TextBox uxUserText;
        private PictureBox uxSpinner;
        private Button uxRecordButton;
    }
}
