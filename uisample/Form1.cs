﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        public Point mouseLocation;

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            Form form = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Dashboard", ref form);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // TODO: GET RID OF ref (NO NEED FOR IT)
        private void FormFiller(string title, ref Form form)
        {
            labelTitle.Text = title;
            this.panelFormLoad.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoad.Controls.Add(form);
            form.Show();
        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            // TODO: A CONFIG FILE OR CONFIG SETTINGS OR AT LEAST A REUSABLE FUNCTION MIGHT BE IN ORDER HERE TO "DRY" THE CODE
            PanelGlow.Height = ButtonDashboard.Height;
            PanelGlow.Top = ButtonDashboard.Top;
            PanelGlow.Left = ButtonDashboard.Left;
            ButtonDashboard.BackColor = Color.FromArgb(46, 51, 73);

            Form form = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Dashboard", ref form);
        }

        private void ButtonAnalytics_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonAnalytics.Height;
            PanelGlow.Top = ButtonAnalytics.Top;
            PanelGlow.Left = ButtonAnalytics.Left;
            ButtonAnalytics.BackColor = Color.FromArgb(46, 51, 73);

            Form form = new formAnalytics() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Analytics", ref form);
        }

        private void ButtonCalendar_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonCalendar.Height;
            PanelGlow.Top = ButtonCalendar.Top;
            PanelGlow.Left = ButtonCalendar.Left;
            ButtonCalendar.BackColor = Color.FromArgb(46, 51, 73);

            Form form = new formCalendar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Calendar", ref form);
        }

        private void ButtonContactUs_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonContactUs.Height;
            PanelGlow.Top = ButtonContactUs.Top;
            PanelGlow.Left = ButtonContactUs.Left;
            ButtonContactUs.BackColor = Color.FromArgb(46, 51, 73);

            Form form = new formContactUs() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Contact Us", ref form);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            PanelGlow.Height = ButtonSettings.Height;
            PanelGlow.Top = ButtonSettings.Top;
            PanelGlow.Left = ButtonSettings.Left;
            ButtonSettings.BackColor = Color.FromArgb(46, 51, 73);

            Form form = new formSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormFiller("Settings", ref form);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point pos = Control.MousePosition;
                pos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = pos;
            }
        }
    }
}
