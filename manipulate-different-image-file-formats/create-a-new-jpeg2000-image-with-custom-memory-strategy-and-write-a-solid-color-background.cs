using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (hardcoded)
        string outputPath = @"C:\temp\output.jp2";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create JPEG2000 options with custom memory strategy
        Jpeg2000Options options = new Jpeg2000Options();
        options.BufferSizeHint = 64; // Memory buffer size hint in MB

        // Create a new JPEG2000 image with specified dimensions and options
        using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
        {
            // Obtain graphics object for drawing
            Graphics graphics = new Graphics(jpeg2000Image);

            // Fill the entire image with a solid blue color
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);
            }

            // Save the image to the output path
            jpeg2000Image.Save(outputPath);
        }
    }
}