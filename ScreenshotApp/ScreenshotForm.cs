using SharpDocx;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenshotApp
{
    public partial class ScreenshotForm : Form
    {
        const string DOC_TEMPLATE = "ScreenshotDocument.cs.docx";

        public ScreenshotForm()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            this.TopMost = true;

            Program.sc.PropertyChanged += Sc_PropertyChanged;
        }

        private void Sc_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
                lbl_status.Text = ((ScreenshotClass)sender).Status;
            if (e.PropertyName == "ImageFiles")
                lbl_TotalScreens.Text = "Total Screenshots: " + ((ScreenshotClass)sender).ImageFiles.Count;
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            if (Program.sc.ImageFiles.Count > 0)
                if (MessageBox.Show(string.Format("Do you want to discard {0} screenshots?", Program.sc.ImageFiles.Count.ToString()), "Discard Screenshots", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.sc.Status = "Screenshots Discarded";
                    Program.sc.DeleteImages();
                    Program.sc.ImageFiles.Clear();
                }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (Program.sc.ImageFiles.Count == 0)
            {
                Program.sc.Status = "Nothing to save";
                return;
            }

            var templatedocument = DocumentFactory.Create(DOC_TEMPLATE, Program.sc);
            var outputdocument = string.IsNullOrWhiteSpace(tb_filename.Text)
                                    ? "ScreenshotDocument_" + DateTime.Now.ToString("ddMMyyyyHHMMss") + ".docx"
                                    : tb_filename.Text + ".docx";

            templatedocument.Generate(outputdocument);

            Program.sc.Status = "Document Saved";
            Process.Start(outputdocument);
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Program.sc.DeleteImages();
            Application.Exit();
        }
    }
}
