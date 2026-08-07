using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\arc_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a pen and a floating‑point rectangle for precise positioning
                Pen pen = new Pen(Color.Blue, 3);
                RectangleF rect = new RectangleF(50.5f, 50.5f, 300.75f, 200.25f);

                // Draw the arc using the floating‑point overload
                graphics.DrawArc(pen, rect, 45f, 270f);

                // Save the image (writes to the specified output path)
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
 * 1. When a developer needs to generate a high‑resolution BMP report that includes precisely positioned curved gauges or dials, they can use Graphics.DrawArc with a RectangleF to draw the arc at sub‑pixel accuracy.
 * 2. When creating custom map overlays in a GIS application where road curves must be rendered on a 24‑bit BMP background, the floating‑point rectangle overload ensures the arcs align correctly with geographic coordinates.
 * 3. When building a medical imaging tool that annotates scanned images with semi‑transparent arc markers to highlight regions of interest, the code demonstrates how to draw those arcs on a BMP canvas using Aspose.Imaging for .NET.
 * 4. When designing a desktop dashboard that visualizes performance metrics as circular progress bars saved as BMP files for printing, the precise positioning provided by RectangleF and DrawArc simplifies the rendering process.
 * 5. When automating the production of printable engineering diagrams that require exact arc dimensions and line thickness on a BMP sheet, this snippet shows how to programmatically draw the arcs with C# and Aspose.Imaging.
 */