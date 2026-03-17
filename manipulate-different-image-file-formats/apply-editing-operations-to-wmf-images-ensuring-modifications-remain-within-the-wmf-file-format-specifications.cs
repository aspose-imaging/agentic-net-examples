using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.Brushes;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input WMF file path
            string inputPath = @"C:\Temp\input.wmf";
            // Output WMF file path
            string outputPath = @"C:\Temp\output.wmf";

            // Load the existing WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Create a recorder that works on the loaded WMF image
                WmfRecorderGraphics2D recorder = WmfRecorderGraphics2D.FromWmfImage(wmfImage);

                // Draw a black border around the image
                recorder.DrawRectangle(new Pen(Color.Black, 1), 0, 0, wmfImage.Width, wmfImage.Height);

                // Fill an inner rectangle with a light gray color
                using (var fillBrush = new SolidBrush(Color.LightGray))
                {
                    recorder.FillRectangle(fillBrush, new Rectangle(10, 10, wmfImage.Width - 20, wmfImage.Height - 20));
                }

                // Draw a diagonal red line
                recorder.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(wmfImage.Width, wmfImage.Height));

                // Add a text annotation
                recorder.DrawString("Edited WMF", new Font("Arial", 24, FontStyle.Regular), Color.Blue, 50, 50);

                // Finalize recording and obtain the modified WMF image
                using (WmfImage editedImage = recorder.EndRecording())
                {
                    // Save the edited WMF image
                    editedImage.Save(outputPath);
                }
            }
        }
    }
}