using SharpDocx;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenshotApp
{
    public partial class ScreenshotForm : Form
    {
        const string DOC_TEMPLATE = "ScreenshotDocument.cs.docx";
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

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
                                    ? "ScreenshotDocument_" + DateTime.Now.ToString("ddMMyyyyHHMMss")
                                    : tb_filename.Text;

            string outputpath = "";

            using(SaveFileDialog savediag = new SaveFileDialog())
            {
                savediag.FileName = outputdocument;
                savediag.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                savediag.Title = "Save Screenshot Document";
                savediag.CheckFileExists = false;
                savediag.CheckPathExists = true;
                savediag.DefaultExt = "docx";
                savediag.Filter = "Microsoft Word Document (*.docx)|*.docx";                
                savediag.RestoreDirectory = true;

                if (savediag.ShowDialog() == DialogResult.OK)
                    outputpath = savediag.FileName;
                else
                {
                    Program.sc.Status = "Save Canceled";
                    return;
                }
            }

            templatedocument.Generate(outputpath);

            Program.sc.Status = "Document Saved";
            Process.Start(outputpath);
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Program.sc.DeleteImages();
            Application.Exit();
        }

        private void ScreenshotForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        
        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void ScreenshotForm_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void ScreenshotForm_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = .7;
        }
    }
}
