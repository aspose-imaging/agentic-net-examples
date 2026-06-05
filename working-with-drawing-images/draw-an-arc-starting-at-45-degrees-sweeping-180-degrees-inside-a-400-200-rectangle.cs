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
            // Output file path (hard‑coded)
            string outputPath = "output\\arc.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400×200 image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 200))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Optional: clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw an arc inside the rectangle (0,0,400,200) starting at 45° sweeping 180°
                graphics.DrawArc(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Rectangle(0, 0, 400, 200),
                    45f,
                    180f);

                // Save the image (no parameters needed because the file source is already bound)
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
 * 1. When generating a PNG badge that includes a semi‑circular progress indicator for a web dashboard, a developer can use this code to draw a 180° arc inside a 400 × 200 rectangle.
 * 2. When creating printable marketing flyers that require a decorative half‑ellipse shape, the code can render the arc in a high‑resolution PNG using Aspose.Imaging’s Graphics.DrawArc method.
 * 3. When building a C# reporting tool that visualizes temperature ranges as arcs on a 400 × 200 canvas, this snippet provides a quick way to draw the arc and save it as a PNG file.
 * 4. When developing an educational app that illustrates geometric concepts such as angles and arcs, the example shows how to programmatically draw a 45°‑start, 180°‑sweep arc in a PNG image.
 * 5. When automating the generation of custom QR‑code overlays that need a curved border around the code, the code can create the curved border as an arc in a 400 × 200 PNG using Aspose.Imaging.
 */