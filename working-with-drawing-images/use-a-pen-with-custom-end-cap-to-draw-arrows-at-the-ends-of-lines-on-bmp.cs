using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\arrow.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image bound to the output file
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with an arrow end cap
                Pen pen = new Pen(Color.Black, 5);
                pen.EndCap = LineCap.ArrowAnchor; // arrow at the end of the line

                // Draw horizontal line with arrow
                graphics.DrawLine(pen, 50, 250, 450, 250);
                // Draw vertical line with arrow
                graphics.DrawLine(pen, 250, 50, 250, 450);

                // Save the image (already bound to the output path)
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
 * 1. When generating a simple diagram for a Windows desktop application that needs a 24‑bit BMP file with arrows indicating direction on lines, a developer can use this Aspose.Imaging C# code.
 * 2. When creating printable flow‑chart symbols or network topology sketches in BMP format without relying on external drawing tools, the code demonstrates how to draw lines with arrow end caps using a Pen.
 * 3. When automating the production of thumbnail images that highlight vector directions, such as wind or traffic flow arrows, the example shows how to render them directly into a BMP using Aspose.Imaging.
 * 4. When building a reporting module that embeds annotated BMP charts with directional markers into PDF or Word documents, this snippet provides the C# approach to draw arrows on the image.
 * 5. When developing a batch process that adds visual cues to legacy BMP assets—like marking start and end points on schematics—the code illustrates how to programmatically apply a custom LineCap.ArrowAnchor with a Pen.
 */