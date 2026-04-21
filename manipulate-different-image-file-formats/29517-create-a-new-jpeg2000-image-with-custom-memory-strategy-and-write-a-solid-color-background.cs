using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jp2");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG2000 options with a custom memory limit (BufferSizeHint in MB)
            Jpeg2000Options options = new Jpeg2000Options
            {
                // Bind the image to the output file
                Source = new FileCreateSource(outputPath, false),
                // Limit internal buffers to 50 MB
                BufferSizeHint = 50,
                // Optional: use irreversible DWT for better compression
                Irreversible = true
            };

            // Create a new JPEG2000 image of 200x200 pixels using the options above
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(jpeg2000Image);

                // Fill the entire image with a solid blue color
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                }

                // Since the image is bound to a FileCreateSource, simply call Save()
                jpeg2000Image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}