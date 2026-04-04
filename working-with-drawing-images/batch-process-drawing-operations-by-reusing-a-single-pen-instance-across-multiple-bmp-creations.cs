using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output paths for the batch BMP files
        string[] outputPaths = {
            @"C:\Temp\Batch\output1.bmp",
            @"C:\Temp\Batch\output2.bmp",
            @"C:\Temp\Batch\output3.bmp"
        };

        // Reuse a single Pen instance for all drawing operations
        var sharedPen = new Pen(Color.Blue, 5f);

        // Loop through each output path, create image, draw, and save
        foreach (var outputPath in outputPaths)
        {
            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up BMP options with a file create source pointing to the output path
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image of size 500x500
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                var graphics = new Graphics(image);

                // Clear the background to white
                graphics.Clear(Color.White);

                // Draw a rectangle using the shared Pen
                graphics.DrawRectangles(sharedPen, new[]
                {
                    new Rectangle(new Point(50, 50), new Size(200, 150)),
                    new Rectangle(new Point(300, 200), new Size(150, 200))
                });

                // Save the image (writes to the file specified in FileCreateSource)
                image.Save();
            }
        }
    }
}