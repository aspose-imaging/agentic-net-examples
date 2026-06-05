using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample_converted.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG file and save it as PNG (rasterization occurs here)
            using (Image odgImage = Image.Load(inputPath))
            {
                odgImage.Save(outputPath, new PngOptions());
            }

            // Load the generated PNG, apply gamma correction, and save again
            using (Image pngImage = Image.Load(outputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                if (pngImage is RasterImage raster)
                {
                    // Apply gamma correction (example gamma value 2.2)
                    raster.AdjustGamma(2.2f);
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}