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
            string outputPath = @"C:\temp\arc_output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a canvas larger than the rectangle to accommodate the drawing
            using (Image image = Image.Create(pngOptions, 500, 300))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Draw the arc inside a 400×200 rectangle starting at 45° sweeping 180°
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawArc(pen, new Rectangle(0, 0, 400, 200), 45, 180);

                // Save the image (already bound to the output file)
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
 * 1. When generating a PNG badge that includes a semi‑circular progress indicator, a developer can use this code to draw a 180° arc inside a 400 × 200 rectangle.
 * 2. When creating a custom chart image in a C# web service, the arc drawing routine can render a quarter‑circle segment for a gauge or dial visualization.
 * 3. When producing printable PDF assets that require a decorative curved border, the code can generate a PNG overlay with a 45°‑started arc to be merged later.
 * 4. When building a game UI component that shows a rotating compass needle, a developer can pre‑draw the static arc background using Aspose.Imaging’s Graphics.DrawArc method.
 * 5. When automating the generation of marketing banners that need a stylized arc motif, this snippet creates the required PNG file with precise angle and size control.
 */