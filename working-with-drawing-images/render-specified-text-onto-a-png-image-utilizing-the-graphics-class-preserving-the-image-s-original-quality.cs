using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing PNG image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create graphics for drawing
            Graphics graphics = new Graphics(image);

            // Prepare brush and font for text rendering
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Yellow;
                brush.Opacity = 100;

                Font font = new Font("Arial", 48);

                // Draw the specified text onto the image
                graphics.DrawString("Sample Text", font, brush, new PointF(50, 50));
            }

            // Save the modified image as PNG
            PngOptions options = new PngOptions();
            image.Save(outputPath, options);
        }
    }
}