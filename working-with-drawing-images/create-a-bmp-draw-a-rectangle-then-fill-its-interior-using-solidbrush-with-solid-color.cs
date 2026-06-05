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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define rectangle bounds
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(50, 50, 200, 150);

                // Draw rectangle outline
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                // Fill rectangle interior with solid blue brush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a BMP file in C# and draw a bordered rectangle filled with a solid color for a simple UI mock‑up or report graphic.
 * 2. When an application must programmatically create a 24‑bit bitmap thumbnail and highlight a region by drawing and filling a rectangle using Aspose.Imaging’s Graphics, Pen, and SolidBrush classes.
 * 3. When a batch‑processing tool has to add a colored overlay to a specific area of an image, such as marking a selection box on a BMP before saving it to disk.
 * 4. When a Windows service generates diagnostic images that include a solid‑filled rectangle to indicate error zones or sensor ranges in a bitmap format.
 * 5. When a developer wants to produce a printable BMP banner with a black‑outlined rectangle filled with blue to serve as a placeholder for dynamic content in a .NET reporting system.
 */