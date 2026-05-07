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
                // Define new dimensions (example: half size)
                int newWidth = sourceImage.Width / 2;
                int newHeight = sourceImage.Height / 2;

                // Create output image canvas bound to the output file
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image canvas = Image.Create(pngOptions, newWidth, newHeight))
                {
                    // Initialize graphics for the canvas
                    Graphics graphics = new Graphics(canvas);

                    // Set high quality bicubic interpolation for scaling
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Draw the source image scaled to the new size
                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, newWidth, newHeight));

                    // Save the canvas (output file is already bound)
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}