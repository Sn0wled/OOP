namespace Windowing
{
    partial class frmShow
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
            components = new System.ComponentModel.Container();
            tmrClose = new System.Windows.Forms.Timer(components);
            btnCancel = new Button();
            btnOk = new Button();
            txtText = new TextBox();
            SuspendLayout();
            // 
            // tmrClose
            // 
            tmrClose.Interval = 1200;
            tmrClose.Tick += timer1_Tick;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(165, 234);
            btnCancel.Margin = new Padding(1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(300, 129);
            btnOk.Margin = new Padding(1);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(72, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtText
            // 
            txtText.Location = new Point(12, 129);
            txtText.Name = "txtText";
            txtText.Size = new Size(100, 23);
            txtText.TabIndex = 0;
            // 
            // frmShow
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            BackgroundImage = Properties.Resources.bublic;
            ClientSize = new Size(400, 300);
            Controls.Add(txtText);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Font = new Font("Tahoma", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "frmShow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form2";
            TransparencyKey = Color.FromArgb(1, 0, 0);
            Load += frmShow_Load;
            Paint += frmShow_Paint;
            KeyDown += frmShow_KeyDown;
            MouseDown += frmShow_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer tmrClose;
        private Button button1;
        private Button btnCancel;
        private Button btnOk;
        private TextBox txtText;
    }
}