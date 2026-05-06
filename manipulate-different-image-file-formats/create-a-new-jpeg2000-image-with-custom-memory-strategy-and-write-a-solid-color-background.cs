using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.jp2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 200;
            int height = 200;

            // Configure JPEG2000 options with a custom memory buffer size
            Jpeg2000Options options = new Jpeg2000Options
            {
                BufferSizeHint = 1024 * 1024 // 1 MB buffer
            };

            // Create a new JPEG2000 image using the options
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, options))
            {
                // Fill the entire image with a solid blue background
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                // Save the image to the specified path
                jpeg2000Image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}