using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a SolidBrush with a custom color
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.FromArgb(255, 0, 128, 255); // custom ARGB color

                    // Construct a Pen from the SolidBrush
                    Pen pen = new Pen(brush);

                    // Draw a rectangle using the Pen
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
                }

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail with a custom‑colored border for a legacy reporting system that only accepts BMP files.
 * 2. When an application must programmatically create a bitmap canvas and draw a highlighted selection rectangle using a custom ARGB color for a Windows desktop UI.
 * 3. When a batch image‑processing tool has to add a colored rectangular watermark to a series of BMP images before they are archived.
 * 4. When a game asset pipeline requires generating simple BMP sprites with colored outlines for collision boxes using C# and Aspose.Imaging.
 * 5. When a document‑generation service must embed a custom‑colored rectangle into a BMP diagram that will be inserted into PDF reports.
 */