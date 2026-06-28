using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\arc_output.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image with sufficient size to contain the rectangle
            using (Image image = Image.Create(pngOptions, 500, 300))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Define pen for the arc
                Pen pen = new Pen(Color.Black, 2);

                // Draw an arc inside a 400×200 rectangle starting at 45° and sweeping 180°
                // Rectangle positioned at (50,50) to keep it within the image bounds
                graphics.DrawArc(pen, new Rectangle(50, 50, 400, 200), 45, 180);

                // Save the image (the file is already created by the source)
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
 * 1. When generating a PNG badge that includes a semi‑circular progress indicator drawn as an arc inside a 400 × 200 rectangle using Aspose.Imaging’s Graphics.DrawArc in C#.
 * 2. When creating a custom chart thumbnail where a 180‑degree arc represents a data range and needs to be rendered within a defined rectangle in a PNG image.
 * 3. When producing a printable label that requires a decorative curved underline drawn as an arc inside a 400 × 200 rectangle with the Aspose.Imaging Graphics object.
 * 4. When building a UI mockup that visualizes a dial or gauge by drawing an arc segment in a PNG file using the C# DrawArc method and a rectangle boundary.
 * 5. When automating the generation of a marketing banner that includes a stylized curved border drawn inside a 400 × 200 rectangle for consistent PNG output.
 */