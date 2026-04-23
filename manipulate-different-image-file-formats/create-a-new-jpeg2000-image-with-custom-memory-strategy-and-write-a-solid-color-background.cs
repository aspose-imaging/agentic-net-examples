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
            // Output path for the JPEG2000 image
            string outputPath = "C:\\temp\\output.jp2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG2000 options with a custom memory buffer size
            Jpeg2000Options options = new Jpeg2000Options
            {
                Source = new FileCreateSource(outputPath, false),
                BufferSizeHint = 10, // Buffer size hint in MB
                Irreversible = true // Use irreversible DWT (optional)
            };

            // Create a new JPEG2000 image with the specified options
            using (Jpeg2000Image canvas = new Jpeg2000Image(200, 200, options))
            {
                // Obtain a graphics object for drawing
                Graphics graphics = new Graphics(canvas);

                // Fill the entire image with a solid blue color
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, canvas.Bounds);
                }

                // Save the bound image (no path needed because it's already bound)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}