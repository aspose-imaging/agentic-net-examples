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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Configure pen with an arrow end cap
                Pen pen = new Pen(Color.Black, 5f);
                pen.EndCap = LineCap.ArrowAnchor;

                // Draw a horizontal line with arrow at the end
                graphics.DrawLine(pen, new Point(50, 200), new Point(350, 200));

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a 24‑bit BMP diagram in C# that visualizes directional flow, such as a pipeline or process step, and wants to draw arrows at the ends of lines using a Pen with a custom ArrowAnchor end cap.
 * 2. When creating printable engineering schematics where the output must be a BMP file and the lines require arrowheads to indicate force direction or signal flow, leveraging Aspose.Imaging’s Graphics and Pen objects.
 * 3. When building a Windows desktop reporting tool that exports charts as BMP images and requires arrows on axis lines to highlight trends, using the Pen.EndCap property for arrow styling.
 * 4. When automating the production of instructional graphics for user manuals, and the developer wants to programmatically add arrow‑styled line endings to illustrate step‑by‑step directions in a BMP image.
 * 5. When integrating Aspose.Imaging into a batch image generation pipeline that creates BMP icons with arrow markers to denote navigation directions in a UI mockup, employing the Pen with LineCap.ArrowAnchor.
 */