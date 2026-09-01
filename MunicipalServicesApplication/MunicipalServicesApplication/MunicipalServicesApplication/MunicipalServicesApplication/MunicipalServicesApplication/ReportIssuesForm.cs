using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApplication
{
    public class ReportIssuesForm : Form
    {
        private static List<Issue> reportedIssues =
            new List<Issue>();

        private Label lblTitle;
        private Label lblLocation;
        private Label lblCategory;
        private Label lblDescription;
        private Label lblAttachment;
        private Label lblFileName;
        private Label lblProgressTitle;
        private Label lblProgressMessage;

        private TextBox txtLocation;

        private ComboBox cmbCategory;

        private RichTextBox rtbDescription;

        private ProgressBar progressReport;

        private Button btnAttach;
        private Button btnSubmit;
        private Button btnBack;

        private string selectedFilePath = "";

        public ReportIssuesForm()
        {
            InitializeForm();

            CreateControls();

            UpdateProgress();
        }


        private void InitializeForm()
        {
            Text =
                "Report a Municipal Issue";

            StartPosition =
                FormStartPosition.CenterScreen;

            Size =
                new Size(950, 750);

            MinimumSize =
                new Size(800, 650);

            BackColor =
                Color.White;

            Font =
                new Font("Segoe UI", 10);
        }


        private void CreateControls()
        {
            lblTitle =
                new Label();

            lblTitle.Text =
                "REPORT A MUNICIPAL ISSUE";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold
                );

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(250, 30);


            lblLocation =
                new Label();

            lblLocation.Text =
                "Location";

            lblLocation.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            lblLocation.Location =
                new Point(70, 105);

            lblLocation.AutoSize =
                true;


            txtLocation =
                new TextBox();

            txtLocation.Name =
                "txtLocation";

            txtLocation.Location =
                new Point(250, 100);

            txtLocation.Size =
                new Size(570, 30);

            txtLocation.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            txtLocation.TextChanged +=
                InputChanged;


            lblCategory =
                new Label();

            lblCategory.Text =
                "Issue Category";

            lblCategory.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            lblCategory.Location =
                new Point(70, 160);

            lblCategory.AutoSize =
                true;


            cmbCategory =
                new ComboBox();

            cmbCategory.Name =
                "cmbCategory";

            cmbCategory.Location =
                new Point(250, 155);

            cmbCategory.Size =
                new Size(570, 30);

            cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;


            cmbCategory.Items.AddRange(
                new string[]
                {
                    "Roads",
                    "Water",
                    "Electricity",
                    "Sanitation",
                    "Waste Management",
                    "Street Lighting",
                    "Public Safety",
                    "Other"
                }
            );

            cmbCategory.SelectedIndexChanged +=
                InputChanged;


            lblDescription =
                new Label();

            lblDescription.Text =
                "Issue Description";

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            lblDescription.Location =
                new Point(70, 215);

            lblDescription.AutoSize =
                true;


            rtbDescription =
                new RichTextBox();

            rtbDescription.Name =
                "rtbDescription";

            rtbDescription.Location =
                new Point(250, 210);

            rtbDescription.Size =
                new Size(570, 130);

            rtbDescription.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            rtbDescription.TextChanged +=
                InputChanged;


            lblAttachment =
                new Label();

            lblAttachment.Text =
                "Attachment";

            lblAttachment.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            lblAttachment.Location =
                new Point(70, 380);

            lblAttachment.AutoSize =
                true;


            btnAttach =
                new Button();

            btnAttach.Text =
                "Attach Image / Document";

            btnAttach.Location =
                new Point(250, 375);

            btnAttach.Size =
                new Size(220, 40);

            btnAttach.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnAttach.Click +=
                BtnAttach_Click;


            lblFileName =
                new Label();

            lblFileName.Text =
                "No file selected";

            lblFileName.Location =
                new Point(490, 387);

            lblFileName.AutoSize =
                true;


            lblProgressTitle =
                new Label();

            lblProgressTitle.Text =
                "Report Progress";

            lblProgressTitle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            lblProgressTitle.Location =
                new Point(70, 455);

            lblProgressTitle.AutoSize =
                true;


            progressReport =
                new ProgressBar();

            progressReport.Name =
                "progressReport";

            progressReport.Location =
                new Point(250, 450);

            progressReport.Size =
                new Size(570, 30);

            progressReport.Minimum =
                0;

            progressReport.Maximum =
                100;


            lblProgressMessage =
                new Label();

            lblProgressMessage.Text =
                "Please complete the required information.";

            lblProgressMessage.Location =
                new Point(250, 490);

            lblProgressMessage.AutoSize =
                true;


            btnSubmit =
                new Button();

            btnSubmit.Text =
                "Submit Report";

            btnSubmit.Location =
                new Point(250, 550);

            btnSubmit.Size =
                new Size(220, 55);

            btnSubmit.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            btnSubmit.Click +=
                BtnSubmit_Click;


            btnBack =
                new Button();

            btnBack.Text =
                "Back to Main Menu";

            btnBack.Location =
                new Point(500, 550);

            btnBack.Size =
                new Size(220, 55);

            btnBack.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold
                );

            btnBack.Click +=
                BtnBack_Click;


            Controls.Add(lblTitle);

            Controls.Add(lblLocation);

            Controls.Add(txtLocation);

            Controls.Add(lblCategory);

            Controls.Add(cmbCategory);

            Controls.Add(lblDescription);

            Controls.Add(rtbDescription);

            Controls.Add(lblAttachment);

            Controls.Add(btnAttach);

            Controls.Add(lblFileName);

            Controls.Add(lblProgressTitle);

            Controls.Add(progressReport);

            Controls.Add(lblProgressMessage);

            Controls.Add(btnSubmit);

            Controls.Add(btnBack);
        }


        private void InputChanged(
            object sender,
            EventArgs e)
        {
            UpdateProgress();
        }


        private void UpdateProgress()
        {
            int progress = 0;


            if (!string.IsNullOrWhiteSpace(
                txtLocation.Text))
            {
                progress += 25;
            }


            if (cmbCategory.SelectedIndex >= 0)
            {
                progress += 25;
            }


            if (!string.IsNullOrWhiteSpace(
                rtbDescription.Text))
            {
                progress += 25;
            }


            if (!string.IsNullOrWhiteSpace(
                selectedFilePath))
            {
                progress += 25;
            }


            progressReport.Value =
                progress;


            if (progress == 0)
            {
                lblProgressMessage.Text =
                    "Please complete the required information.";
            }

            else if (progress == 25)
            {
                lblProgressMessage.Text =
                    "Good start! Please select a category.";
            }

            else if (progress == 50)
            {
                lblProgressMessage.Text =
                    "Great! Now describe the issue.";
            }

            else if (progress == 75)
            {
                lblProgressMessage.Text =
                    "Almost there! Attach supporting evidence if available.";
            }

            else
            {
                lblProgressMessage.Text =
                    "Excellent! Your report is ready to submit.";
            }
        }


        private void BtnAttach_Click(
            object sender,
            EventArgs e)
        {
            using (
                OpenFileDialog openFileDialog =
                new OpenFileDialog())
            {
                openFileDialog.Title =
                    "Select an Image or Document";


                openFileDialog.Filter =
                    "Supported Files|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx|" +
                    "Image Files|*.jpg;*.jpeg;*.png|" +
                    "Document Files|*.pdf;*.doc;*.docx|" +
                    "All Files|*.*";


                if (
                    openFileDialog.ShowDialog()
                    == DialogResult.OK)
                {
                    selectedFilePath =
                        openFileDialog.FileName;


                    lblFileName.Text =
                        "Attached: " +
                        Path.GetFileName(
                            selectedFilePath);


                    UpdateProgress();
                }
            }
        }


        private void BtnSubmit_Click(
            object sender,
            EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(
                    txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLocation.Focus();

                return;
            }


            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select an issue category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategory.Focus();

                return;
            }


            if (
                string.IsNullOrWhiteSpace(
                    rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a detailed description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                rtbDescription.Focus();

                return;
            }


            Issue newIssue =
                new Issue
                {
                    IssueId =
                        reportedIssues.Count + 1,

                    Location =
                        txtLocation.Text.Trim(),

                    Category =
                        cmbCategory.SelectedItem.ToString(),

                    Description =
                        rtbDescription.Text.Trim(),

                    Attachment =
                        selectedFilePath,

                    DateReported =
                        DateTime.Now
                };


            reportedIssues.Add(
                newIssue);


            MessageBox.Show(
                "Report Submitted Successfully!\n\n" +
                "Thank you for helping improve your community. " +
                "Your issue has been recorded.",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );


            ClearForm();
        }


        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex =
                -1;

            rtbDescription.Clear();

            selectedFilePath =
                "";

            lblFileName.Text =
                "No file selected";

            progressReport.Value =
                0;

            lblProgressMessage.Text =
                "Please complete the required information.";

            txtLocation.Focus();
        }


        private void BtnBack_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
