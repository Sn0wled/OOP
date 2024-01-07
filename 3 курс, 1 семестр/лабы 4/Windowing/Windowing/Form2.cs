using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windowing
{
    public partial class frmShow : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(
            IntPtr hWnd, uint Msg, uint wParam, uint lParam);
        const uint WM_SYSCOMMAND = 0x0112;
        const uint SC_MOVE = 0xF012;
        string msg;
        public void SetMessage(string text)
        {
            msg = text;
        }
        public frmShow()
        {
            InitializeComponent();
        }

        public string GetMessage()
        {
            return msg;
        }

        private void frmShow_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.01)
            {
                tmrClose.Enabled = false;
            }
            Opacity -= 0.02;
            if (tmrClose.Interval > 1000)
            {
                tmrClose.Interval = 10;
            }
        }

        private void frmShow_Paint(object sender, PaintEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, msg, Font, new Rectangle(0, 0, Width, Height), SystemColors.ControlText,
                flags);
            /*tmrClose.Enabled = true;*/
        }

        private void frmShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tmrClose.Stop();
                Close();
            }
        }

        private void frmShow_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            PostMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            msg = txtText.Text;
        }
    }
}
