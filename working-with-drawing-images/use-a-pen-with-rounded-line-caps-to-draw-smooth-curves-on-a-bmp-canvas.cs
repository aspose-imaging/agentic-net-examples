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
            string outputPath = "output\\smooth_curve.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            int canvasWidth = 800;
            int canvasHeight = 600;

            // Create canvas
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Pen for drawing
                Pen pen = new Pen(Color.Blue, 5);

                // Points for smooth curve
                Point[] curvePoints = new Point[]
                {
                    new Point(100, 500),
                    new Point(200, 100),
                    new Point(400, 300),
                    new Point(600, 150),
                    new Point(700, 450)
                };

                // Draw the curve
                graphics.DrawCurve(pen, curvePoints);

                // Save the image (bound to the file source)
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
 * 1. When a developer needs to generate a high‑resolution BMP file that visualizes a smooth, blue curve for a scientific chart or engineering diagram using C# and Aspose.Imaging.
 * 2. When an application must programmatically create a white background canvas, draw anti‑aliased curved paths with a Pen that has rounded line caps, and export the result as a BMP for legacy Windows printing.
 * 3. When a reporting tool has to embed custom spline graphics—such as a route map or trend line—directly into a BMP image without relying on external drawing libraries.
 * 4. When an automated image‑processing pipeline requires creating placeholder graphics with smooth curves to test OCR or image‑analysis algorithms on BMP files.
 * 5. When a game‑development utility needs to pre‑render decorative curve assets (e.g., borders or UI elements) into BMP sprites using Aspose.Imaging’s Graphics.DrawCurve method.
 */