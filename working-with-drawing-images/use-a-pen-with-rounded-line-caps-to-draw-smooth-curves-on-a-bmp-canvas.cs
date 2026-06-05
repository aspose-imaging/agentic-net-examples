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
            // Define output path (hardcoded)
            string outputPath = @"output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions { Source = source };

            // Define canvas size
            int width = 500;
            int height = 300;

            // Create a BMP canvas (bound to the output file)
            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Create a pen with rounded line caps for smooth curves
                Pen pen = new Pen(Color.Blue, 5);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // Define points for the curve
                Point[] points = new Point[]
                {
                    new Point(50, 250),
                    new Point(150, 50),
                    new Point(250, 250),
                    new Point(350, 50),
                    new Point(450, 250)
                };

                // Draw the smooth curve
                graphics.DrawCurve(pen, points);

                // Save the bound image
                canvas.Save();
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
 * 1. When generating a BMP signature stamp with Aspose.Imaging in C#, a Pen with rounded line caps is used to draw smooth, handwritten‑style curves.
 * 2. When creating a BMP waveform image for an audio analysis dashboard, developers use a Pen with rounded caps to render the curve’s peaks and troughs with a polished look.
 * 3. When producing a BMP map overlay that shows curved road routes, a rounded‑cap Pen ensures the lines appear smooth and visually consistent.
 * 4. When exporting a BMP flowchart diagram, using a Pen with rounded line caps for connector curves improves readability and professional appearance.
 * 5. When building a BMP thumbnail of a CAD sketch, a Pen with rounded caps draws the curved edges so the preview looks clean and high‑quality.
 */