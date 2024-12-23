using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace uisample
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
        );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            // TODO: A CONFIG FILE OR CONFIG SETTINGS OR AT LEAST A REUSABLE FUNCTION MIGHT BE IN ORDER HERE TO "DRY" THE CODE
            PanelGlow.Height = ButtonDashboard.Height;
            PanelGlow.Top = ButtonDashboard.Top;
            PanelGlow.Left = ButtonDashboard.Left;
            ButtonDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void ButtonAnalytics_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonAnalytics.Height;
            PanelGlow.Top = ButtonAnalytics.Top;
            PanelGlow.Left = ButtonAnalytics.Left;
            ButtonAnalytics.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void ButtonCalendar_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonCalendar.Height;
            PanelGlow.Top = ButtonCalendar.Top;
            PanelGlow.Left = ButtonCalendar.Left;
            ButtonCalendar.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void ButtonContactUs_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonContactUs.Height;
            PanelGlow.Top = ButtonContactUs.Top;
            PanelGlow.Left = ButtonContactUs.Left;
            ButtonContactUs.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonSettings.Height;
            PanelGlow.Top = ButtonSettings.Top;
            PanelGlow.Left = ButtonSettings.Left;
            ButtonSettings.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void ButtonDashboard_Leave(object sender, EventArgs e)
        {
            // TODO: A CONFIG FILE OR CONFIG SETTINGS OR AT LEAST A REUSABLE FUNCTION MIGHT BE IN ORDER HERE TO "DRY" THE CODE
            ButtonDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ButtonAnalytics_Leave(object sender, EventArgs e)
        {
            ButtonAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ButtonCalendar_Leave(object sender, EventArgs e)
        {
            ButtonCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ButtonContactUs_Leave(object sender, EventArgs e)
        {
            ButtonContactUs.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ButtonSettings_Leave(object sender, EventArgs e)
        {
            ButtonSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
