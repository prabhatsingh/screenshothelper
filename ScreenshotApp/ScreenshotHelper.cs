using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ScreenshotApp
{
    class ScreenshotHelper
    {
        public static void TakeScreenshot()
        {
            Program.sc.Status = "Screenshot Taken";

            var image = ScreenCapture.CaptureActiveWindow();
            var imagename = string.Format("{0}screenshot_{1}.jpg", Path.GetTempPath(),Program.sc.ImageFiles.Count + 1);
            image.Save(imagename, ImageFormat.Jpeg);
            Program.sc.ImageFiles.Add(imagename);
            Console.WriteLine(imagename);
            Console.WriteLine(Program.sc.ImageFiles.Count);
        }
    }

    public class ScreenshotClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string status;

        public string Status
        {
            get => status; set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<string> ImageFiles
        {
            get
            {
                if (_imageFiles == null)
                {
                    _imageFiles = new ObservableCollection<string>();
                    _imageFiles.CollectionChanged += _imageFiles_CollectionChanged;
                }
                return _imageFiles;
            }
            set => _imageFiles = value;
        }

        private void _imageFiles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("ImageFiles");
        }

        private ObservableCollection<string> _imageFiles;

        public void DeleteImages()
        {
            _imageFiles?.ToList().ForEach(f => { if (File.Exists(f)) File.Delete(f); });
        }
    }

    public class ScreenCapture
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Image CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }
    }
}
