using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image as raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define scaling factor (e.g., 2x)
            int scaledWidth = sourceImage.Width * 2;
            int scaledHeight = sourceImage.Height * 2;

            // Create a new canvas image with desired size
            PngOptions pngOptions = new PngOptions();
            using (Image canvas = Image.Create(pngOptions, scaledWidth, scaledHeight))
            {
                // Initialize graphics for the canvas
                Graphics graphics = new Graphics(canvas);

                // Set high-quality bicubic interpolation for scaling
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the source image onto the canvas, scaling it to fit
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, scaledWidth, scaledHeight));

                // Save the resulting image to the output path
                canvas.Save(outputPath, pngOptions);
            }
        }
    }
}