using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\scaled.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image as RasterImage
        using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
        {
            // Define new dimensions (e.g., double size)
            int newWidth = srcImage.Width * 2;
            int newHeight = srcImage.Height * 2;

            // Create destination image (PNG) with desired size
            PngOptions pngOptions = new PngOptions();
            using (Image destImage = Image.Create(pngOptions, newWidth, newHeight))
            {
                // Initialize Graphics for the destination image
                Graphics graphics = new Graphics(destImage);

                // Set high-quality bicubic interpolation for scaling
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the source image scaled to the new dimensions
                graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));

                // Save the resulting image
                destImage.Save(outputPath, pngOptions);
            }
        }
    }
}