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
            // Output file path
            string outputPath = "output\\s_curve.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a stream source
            using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(outStream);

                // Create a 500x500 image canvas
                using (Image image = Image.Create(bmpOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Define points for an S‑shaped Bezier curve
                    PointF pt1 = new PointF(100, 400);
                    PointF pt2 = new PointF(150, 100);
                    PointF pt3 = new PointF(350, 300);
                    PointF pt4 = new PointF(400, 50);

                    // Draw the curve
                    Pen pen = new Pen(Color.Blue, 3);
                    graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                    // Save the image (stream is already bound)
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
 * 1. When a developer needs to generate a printable signature line with a smooth S‑shaped curve in a BMP file for a PDF form.
 * 2. When creating custom UI icons or buttons that require an elegant S‑curve drawn directly onto a 500×500 bitmap using C# and Aspose.Imaging.
 * 3. When producing a flow‑chart diagram where the connector between two process boxes is represented by an S‑shaped Bezier curve saved as a BMP image.
 * 4. When rendering a stylized road or river path on a map thumbnail, using PointF coordinates to draw a smooth S‑curve and exporting it as a BMP for web display.
 * 5. When automating the generation of decorative header graphics for reports, drawing an S‑shaped curve with a blue pen onto a BMP canvas before embedding it into a document.
 */