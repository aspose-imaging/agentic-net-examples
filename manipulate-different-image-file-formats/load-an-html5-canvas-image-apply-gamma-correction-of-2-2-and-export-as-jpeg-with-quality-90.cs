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
            string inputPath = @"C:\temp\canvas.png";
            string outputPath = @"C:\temp\canvas_gamma.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (HTML5 canvas saved as PNG)
            using (Image image = Image.Load(inputPath))
            {
                // Apply gamma correction of 2.2
                if (image is RasterImage raster)
                {
                    raster.AdjustGamma(2.2f);
                }
                else if (image is RasterCachedImage cached)
                {
                    cached.AdjustGamma(2.2f);
                }
                else
                {
                    // Fallback for other image types that support AdjustGamma
                    dynamic dyn = image;
                    dyn.AdjustGamma(2.2f);
                }

                // Save as JPEG with quality 90
                var jpegOptions = new JpegOptions { Quality = 90 };
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}