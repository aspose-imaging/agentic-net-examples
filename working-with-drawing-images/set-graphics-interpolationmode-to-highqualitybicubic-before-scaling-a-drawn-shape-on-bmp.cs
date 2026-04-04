using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Set high-quality bicubic interpolation before scaling
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Apply scaling transform (e.g., 2x)
            graphics.ScaleTransform(2.0f, 2.0f);

            // Draw a rectangle (scaled by the transform)
            Pen pen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(pen, new Rectangle(10, 10, 100, 50));

            // Save the modified image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }
    }
}