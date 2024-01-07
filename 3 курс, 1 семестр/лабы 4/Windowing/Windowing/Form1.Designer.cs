namespace Windowing
{
    partial class frmMain
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
            btnClose = new Button();
            btnShow = new Button();
            lblText = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 385);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(713, 356);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 1;
            btnShow.Text = "Показать";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Location = new Point(12, 9);
            lblText.Name = "lblText";
            lblText.Size = new Size(38, 14);
            lblText.TabIndex = 2;
            lblText.Text = "label1";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnClose;
            ClientSize = new Size(800, 420);
            Controls.Add(lblText);
            Controls.Add(btnShow);
            Controls.Add(btnClose);
            Font = new Font("Tahoma", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Location = new Point(100, 100);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Windowing";
            FormClosing += frmMain_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnShow;
        private Label lblText;
    }
}
