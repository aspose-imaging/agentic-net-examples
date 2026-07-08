using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "Output\\highres.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set PNG options
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Define image size
            int width = 1000;
            int height = 1000;

            // Create image bound to the output file
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Fill background rectangle
                using (SolidBrush backgroundBrush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(backgroundBrush, new Rectangle(100, 100, 800, 800));
                }

                // Draw ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 5), new Rectangle(200, 200, 600, 600));

                // Draw diagonal line
                graphics.DrawLine(new Pen(Color.Green, 3), new Point(100, 100), new Point(900, 900));

                // Draw polygon
                Point[] polygonPoints = new Point[]
                {
                    new Point(500, 100),
                    new Point(800, 400),
                    new Point(500, 700),
                    new Point(200, 400)
                };
                graphics.DrawPolygon(new Pen(Color.Blue, 4), polygonPoints);

                // Draw text
                Font font = new Font("Arial", 48);
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString("High DPI", font, textBrush, new PointF(300, 500));
                }

                // Save the image (output file already bound)
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
 * 1. When a developer needs to generate a print‑ready 300 DPI PNG badge with crisp vector shapes for a conference ID card.
 * 2. When building a web service that creates custom product labels (e.g., wine bottles) on the fly, requiring high‑resolution PNG output with scalable ellipses, lines, and text.
 * 3. When producing marketing assets such as flyers or posters programmatically, where the 300 DPI image ensures sharpness for large‑format printing while using Aspose.Imaging to draw shapes and typography.
 * 4. When developing a desktop application that exports user‑drawn diagrams to a high‑resolution PNG file for inclusion in technical documentation, preserving line weight and font clarity.
 * 5. When automating the creation of UI mockups or icon sets that must retain crisp edges at any size, using C# and Aspose.Imaging to render vector graphics at 300 DPI for designers.
 */