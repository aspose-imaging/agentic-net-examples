// HOW-TO: Draw High Precision Bezier Curve with Points in PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\bezier.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set PNG options with the stream as source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a 500x500 PNG image
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                    // Clear background to white
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Define a blue pen for the Bezier curve
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                    // Draw a Bezier curve using Point structures
                    graphics.DrawBezier(
                        pen,
                        new Aspose.Imaging.Point(50, 250),   // start point
                        new Aspose.Imaging.Point(150, 50),   // first control point
                        new Aspose.Imaging.Point(350, 450),  // second control point
                        new Aspose.Imaging.Point(450, 250)   // end point
                    );

                    // Save the image (writes to the stream)
                    image.Save();
                }
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
 * 1. When you need to generate a PNG diagram that includes a smooth, high‑precision Bezier curve for UI mockups or technical illustrations.
 * 2. When you want to programmatically create vector‑style graphics in a bitmap image for reports, using Aspose.Imaging’s Graphics.DrawBezier with Point structures.
 * 3. When you must render custom curved paths in a server‑side C# service that outputs PNG files for web thumbnails or email attachments.
 * 4. When you are building a CAD‑like preview where control points are defined as points and you need exact curve placement without loss of precision.
 * 5. When you require automated drawing of scalable curves in batch processing, saving each result directly to a file stream for efficient storage.
 */
