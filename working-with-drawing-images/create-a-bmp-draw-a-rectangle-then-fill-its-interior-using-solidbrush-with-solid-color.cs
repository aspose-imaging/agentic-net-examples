// HOW-TO: Create BMP Image With Filled Rectangle Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Define a pen for the rectangle border
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(20, 20, 160, 160));

                // Fill the rectangle interior with a solid brush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(20, 20, 160, 160));
                }

                // Save the image to the specified path
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
 * 1. When you need to generate a simple BMP thumbnail with a colored box for a Windows desktop application.
 * 2. When you want to programmatically create a bitmap badge or icon that includes a solid‑filled shape for UI overlays.
 * 3. When you must produce a BMP report graphic that highlights a region by drawing and filling a rectangle in C#.
 * 4. When an automated tool has to add a colored rectangle watermark to a batch of BMP files during image preprocessing.
 * 5. When you are building a test image to verify that Aspose.Imaging correctly renders pens and solid brushes on bitmap canvases.
 */
