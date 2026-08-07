using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options (24 bits per pixel)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 500;
            int height = 500;

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object for drawing
                var graphics = new Graphics(image);

                // Draw a black rectangle border
                graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);

                // Fill an inner rectangle with solid red brush
                var fillBrush = new SolidBrush(Color.Red);
                var fillRect = new Rectangle(10, 10, width - 20, height - 20);
                graphics.FillRectangle(fillBrush, fillRect);

                // Save the image (writes to the FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically create a 24‑bit BMP thumbnail with a solid‑filled rectangle for a legacy Windows application that only supports BMP files.
 * 2. When an automated reporting tool must generate a simple rectangular badge image in C# using Aspose.Imaging, drawing a border and filling it with a solid color for inclusion in PDF reports.
 * 3. When a game asset pipeline requires creating placeholder texture files in BMP format with a solid‑filled rectangle to test rendering pipelines before final art is available.
 * 4. When a document management system needs to add a visual indicator by generating a BMP image with a solid‑colored rectangle overlay to denote document status.
 * 5. When a batch image conversion utility must produce BMP icons with a uniform background color by drawing and filling a rectangle in C# with Aspose.Imaging’s Graphics API.
 */