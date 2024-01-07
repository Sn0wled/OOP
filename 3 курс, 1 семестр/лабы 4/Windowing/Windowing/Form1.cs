namespace Windowing
{
    public partial class frmMain : Form
    {
        private frmShow showForm;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*showForm.Show();
            showForm.BringToFront();
            BringToFront();*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            /*MessageBox.Show(this, "MouseDown", "btnClose", MessageBoxButtons.OK, MessageBoxIcon.Information);*/

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*showForm.Close();*/
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showForm = new frmShow();
            if (showForm.ShowDialog() == DialogResult.OK)
            {
                lblText.Text = showForm.GetMessage();
            }
            else
            {
                lblText.Text = "Отменено пользователем";
            }
        }
    }
}
