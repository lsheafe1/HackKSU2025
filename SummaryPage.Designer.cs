namespace HackKSU2025
{
    partial class SummaryPage
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
            uxButtonContainer = new FlowLayoutPanel();
            uxBack = new Button();
            uxNew = new Button();
            uxMessageBox = new RichTextBox();
            label1 = new Label();
            uxButtonContainer.SuspendLayout();
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
            uxButtonContainer.Size = new Size(242, 66);
            uxButtonContainer.TabIndex = 3;
            // 
            // uxBack
            // 
            uxBack.AutoSize = true;
            uxBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uxBack.BackColor = Color.CadetBlue;
            uxBack.Cursor = Cursors.Hand;
            uxBack.FlatStyle = FlatStyle.Flat;
            uxBack.Font = new Font("Cooper Black", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxBack.ForeColor = Color.Azure;
            uxBack.Location = new Point(10, 10);
            uxBack.Margin = new Padding(10);
            uxBack.Name = "uxBack";
            uxBack.Size = new Size(107, 46);
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
            uxNew.Font = new Font("Cooper Black", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uxNew.ForeColor = Color.Azure;
            uxNew.Location = new Point(137, 10);
            uxNew.Margin = new Padding(10);
            uxNew.Name = "uxNew";
            uxNew.Size = new Size(95, 46);
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
            uxMessageBox.TabIndex = 4;
            uxMessageBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.CadetBlue;
            label1.Location = new Point(440, 57);
            label1.Name = "label1";
            label1.Size = new Size(131, 27);
            label1.TabIndex = 5;
            label1.Text = "Summary";
            // 
            // SummaryPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(label1);
            Controls.Add(uxButtonContainer);
            Controls.Add(uxMessageBox);
            Name = "SummaryPage";
            Size = new Size(1024, 768);
            uxButtonContainer.ResumeLayout(false);
            uxButtonContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel uxButtonContainer;
        private Button uxBack;
        private Button uxNew;
        private RichTextBox uxMessageBox;
        private Label label1;
    }
}
