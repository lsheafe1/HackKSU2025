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
            uxButtonContainer.Location = new Point(31, 23);
            uxButtonContainer.Margin = new Padding(4, 167, 4, 5);
            uxButtonContainer.Name = "uxButtonContainer";
            uxButtonContainer.Size = new Size(321, 98);
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
            uxBack.Location = new Point(14, 17);
            uxBack.Margin = new Padding(14, 17, 14, 17);
            uxBack.Name = "uxBack";
            uxBack.Size = new Size(143, 64);
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
            uxNew.Location = new Point(185, 17);
            uxNew.Margin = new Padding(14, 17, 14, 17);
            uxNew.Name = "uxNew";
            uxNew.Size = new Size(122, 64);
            uxNew.TabIndex = 1;
            uxNew.Text = "New";
            uxNew.UseVisualStyleBackColor = false;
            uxNew.Click += uxNew_Click;
            // 
            // uxMessageBox
            // 
            uxMessageBox.BackColor = Color.Linen;
            uxMessageBox.BorderStyle = BorderStyle.FixedSingle;
            uxMessageBox.Font = new Font("Microsoft Sans Serif", 14.25F);
            uxMessageBox.Location = new Point(29, 170);
            uxMessageBox.Margin = new Padding(4, 5, 4, 5);
            uxMessageBox.Name = "uxMessageBox";
            uxMessageBox.ReadOnly = true;
            uxMessageBox.Size = new Size(1405, 481);
            uxMessageBox.TabIndex = 3;
            uxMessageBox.Text = "";
            uxMessageBox.MouseMove += uxMouseMove;
            // 
            // uxScenarioContainer
            // 
            uxScenarioContainer.Controls.Add(uxSpinner);
            uxScenarioContainer.Controls.Add(uxSendButton);
            uxScenarioContainer.Controls.Add(uxUserText);
            uxScenarioContainer.Controls.Add(uxButtonContainer);
            uxScenarioContainer.Controls.Add(uxMessageBox);
            uxScenarioContainer.Dock = DockStyle.Fill;
            uxScenarioContainer.Location = new Point(0, 0);
            uxScenarioContainer.Margin = new Padding(4, 5, 4, 5);
            uxScenarioContainer.Name = "uxScenarioContainer";
            uxScenarioContainer.Size = new Size(1463, 1280);
            uxScenarioContainer.TabIndex = 4;
            // 
            // uxSpinner
            // 
            uxSpinner.BackColor = Color.Linen;
            uxSpinner.Image = (Image)resources.GetObject("uxSpinner.Image");
            uxSpinner.Location = new Point(29, 540);
            uxSpinner.Margin = new Padding(4, 5, 4, 5);
            uxSpinner.Name = "uxSpinner";
            uxSpinner.Size = new Size(77, 115);
            uxSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            uxSpinner.TabIndex = 6;
            uxSpinner.TabStop = false;
            // 
            // uxSendButton
            // 
            uxSendButton.Location = new Point(1317, 565);
            uxSendButton.Margin = new Padding(4, 5, 4, 5);
            uxSendButton.Name = "uxSendButton";
            uxSendButton.Size = new Size(113, 88);
            uxSendButton.TabIndex = 5;
            uxSendButton.Text = "Send";
            uxSendButton.UseVisualStyleBackColor = true;
            uxSendButton.Click += uxSendClick;
            // 
            // uxUserText
            // 
            uxUserText.BorderStyle = BorderStyle.FixedSingle;
            uxUserText.Location = new Point(740, 567);
            uxUserText.Margin = new Padding(4, 5, 4, 5);
            uxUserText.Multiline = true;
            uxUserText.Name = "uxUserText";
            uxUserText.Size = new Size(575, 87);
            uxUserText.TabIndex = 4;
            uxUserText.KeyDown += uxSendEnter;
            // 
            // ScenarioPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(uxScenarioContainer);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ScenarioPage";
            Size = new Size(1463, 1280);
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
    }
}
