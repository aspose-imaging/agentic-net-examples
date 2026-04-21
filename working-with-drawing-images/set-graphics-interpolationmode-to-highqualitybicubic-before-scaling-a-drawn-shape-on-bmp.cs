using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.bmp";
        string outputPath = "output\\scaled.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Set high-quality bicubic interpolation for scaling operations
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Apply scaling transform (e.g., 2x scaling)
            graphics.ScaleTransform(2.0f, 2.0f);

            // Draw a rectangle shape after scaling
            graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(10, 10, 100, 50));

            // Save the modified image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            image.Save(outputPath, bmpOptions);
        }
    }
}