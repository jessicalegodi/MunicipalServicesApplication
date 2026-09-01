using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApplication
{
    public class MainMenuForm : Form
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Button btnReportIssues;
        private Button btnEvents;
        private Button btnStatus;
        private Button btnExit;

        public MainMenuForm()
        {
            InitializeForm();
            CreateControls();
        }

        private void InitializeForm()
        {
            Text = "Municipal Services Application";

            StartPosition = FormStartPosition.CenterScreen;

            Size = new Size(900, 650);

            MinimumSize = new Size(700, 550);

            BackColor = Color.White;

            Font = new Font("Segoe UI", 10);
        }

        private void CreateControls()
        {
            lblTitle = new Label();

            lblTitle.Text = "MUNICIPAL SERVICES";

            lblTitle.Font =
                new Font("Segoe UI", 26, FontStyle.Bold);

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(270, 55);


            lblSubtitle = new Label();

            lblSubtitle.Text =
                "Report and submit municipal service issues";

            lblSubtitle.Font =
                new Font("Segoe UI", 12);

            lblSubtitle.AutoSize = true;

            lblSubtitle.Location =
                new Point(245, 105);


            btnReportIssues = CreateButton(
                "Report Issues",
                new Point(300, 180),
                new Size(300, 60)
            );


            btnEvents = CreateButton(
                "Local Events and Announcements",
                new Point(300, 260),
                new Size(300, 60)
            );


            btnStatus = CreateButton(
                "Service Request Status",
                new Point(300, 340),
                new Size(300, 60)
            );


            btnExit = CreateButton(
                "Exit",
                new Point(350, 440),
                new Size(200, 50)
            );


            // Features planned for later parts
            btnEvents.Enabled = false;

            btnStatus.Enabled = false;


            btnReportIssues.Click +=
                BtnReportIssues_Click;

            btnExit.Click +=
                BtnExit_Click;


            Controls.Add(lblTitle);

            Controls.Add(lblSubtitle);

            Controls.Add(btnReportIssues);

            Controls.Add(btnEvents);

            Controls.Add(btnStatus);

            Controls.Add(btnExit);
        }

        private Button CreateButton(
            string text,
            Point location,
            Size size)
        {
            Button button = new Button();

            button.Text = text;

            button.Location = location;

            button.Size = size;

            button.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            button.FlatStyle =
                FlatStyle.Flat;

            button.Cursor =
                Cursors.Hand;

            return button;
        }


        private void BtnReportIssues_Click(
            object sender,
            EventArgs e)
        {
            using (
                ReportIssuesForm reportForm =
                new ReportIssuesForm())
            {
                reportForm.ShowDialog();
            }
        }


        private void BtnExit_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to exit the application?",
                    "Exit Application",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
