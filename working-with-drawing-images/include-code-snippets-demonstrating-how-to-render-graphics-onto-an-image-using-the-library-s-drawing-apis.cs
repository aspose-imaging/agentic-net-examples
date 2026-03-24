using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the input image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(raster);

            // Clear the surface with a light color
            graphics.Clear(Color.Wheat);

            // Draw a red line
            graphics.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(200, 50));

            // Draw a blue rectangle
            graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(60, 80, 150, 100));

            // Fill an ellipse with a semi‑transparent green brush
            using (SolidBrush ellipseBrush = new SolidBrush())
            {
                ellipseBrush.Color = Color.Green;
                ellipseBrush.Opacity = 0.5f;
                graphics.FillEllipse(ellipseBrush, new Rectangle(80, 200, 120, 80));
            }

            // Draw a string using a solid purple brush
            using (SolidBrush textBrush = new SolidBrush())
            {
                textBrush.Color = Color.Purple;
                textBrush.Opacity = 1.0f;
                Font font = new Font("Arial", 24);
                graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(70, 320));
            }

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}