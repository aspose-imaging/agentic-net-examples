using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_adjusted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Check for alpha channel support
                bool hasAlpha = false;
                if (image is RasterImage rasterImg)
                {
                    hasAlpha = rasterImg.HasAlpha;
                }
                Console.WriteLine($"Alpha channel present: {hasAlpha}");

                // Apply gamma correction (using a sample gamma value)
                if (image is RasterImage raster)
                {
                    raster.AdjustGamma(2.5f);
                }
                else
                {
                    // Fallback for other image types that may expose AdjustGamma
                    dynamic dyn = image;
                    dyn.AdjustGamma(2.5f);
                }

                // Save the adjusted image as GIF
                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}