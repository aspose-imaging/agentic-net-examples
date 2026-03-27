using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_converted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and rasterize it to PNG
        using (Image odgImage = Image.Load(inputPath))
        {
            // Save as PNG using default PNG options
            odgImage.Save(outputPath, new PngOptions());
        }

        // Load the newly created PNG to apply gamma correction
        using (Image pngImage = Image.Load(outputPath))
        {
            // Cast to RasterImage to access AdjustGamma
            if (pngImage is RasterImage rasterImage)
            {
                // Apply gamma correction (example gamma value 2.2)
                rasterImage.AdjustGamma(2.2f);
                // Overwrite the PNG with gamma‑corrected data
                rasterImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("Loaded image is not a raster image; cannot apply gamma correction.");
            }
        }
    }
}