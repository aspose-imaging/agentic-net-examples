using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            int width = 200;
            int height = 200;
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a thick red line
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 10);
                graphics.DrawLine(redPen, new Aspose.Imaging.Point(10, 10), new Aspose.Imaging.Point(190, 190));

                // Overlay a thinner black line for contrast
                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(blackPen, new Aspose.Imaging.Point(10, 10), new Aspose.Imaging.Point(190, 190));

                // Save the image (source is already bound to the file)
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
 * 1. When a developer needs to create a BMP image with a bold diagonal highlight for a custom UI icon, this code draws a thick red line and adds a thin black line for contrast.
 * 2. When generating printable test patterns that require a high‑visibility guide line, the code produces a BMP file with a red line overlaid by a black line to improve readability.
 * 3. When building a simple graphics editor that supports drawing primitives, this snippet shows how to use Aspose.Imaging in C# to render a thick red stroke and a finer black stroke on a BMP canvas.
 * 4. When automating the creation of watermark overlays for legacy BMP assets, the code demonstrates drawing a prominent red line and a subtle black line to ensure the watermark stands out on any background.
 * 5. When preparing diagnostic images for debugging image‑processing pipelines, developers can use this example to generate a BMP file with a clearly visible red line bordered by a thin black line for easy visual inspection.
 */