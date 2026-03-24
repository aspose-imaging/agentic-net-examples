using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.png";
        string outputPath = @"C:\Temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Check for alpha channel using the common RasterImage property
            bool hasAlpha = false;
            if (image is RasterImage raster)
            {
                hasAlpha = raster.HasAlpha;
                Console.WriteLine($"RasterImage.HasAlpha: {hasAlpha}");
            }

            // Additional PNG‑specific checks
            if (image is PngImage png)
            {
                Console.WriteLine($"PngImage.HasAlpha: {png.HasAlpha}");
                Console.WriteLine($"PngImage.HasTransparentColor: {png.HasTransparentColor}");

                // Example manipulation: set a transparent color if the image lacks alpha
                if (!png.HasAlpha && !png.HasTransparentColor)
                {
                    png.TransparentColor = Color.Red;
                    png.HasTransparentColor = true;
                    Console.WriteLine("Transparent color set to Red.");
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the (potentially modified) image
            image.Save(outputPath);
            Console.WriteLine($"Image saved to {outputPath}");
        }
    }
}