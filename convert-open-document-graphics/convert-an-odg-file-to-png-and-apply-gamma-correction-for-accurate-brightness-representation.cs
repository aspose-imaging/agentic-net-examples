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
        string outputPath = "sample.png";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG file
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save it as PNG (rasterization occurs during save)
                var pngOptions = new PngOptions();
                odgImage.Save(outputPath, pngOptions);
            }

            // Reload the generated PNG to apply gamma correction
            using (Image pngImage = Image.Load(outputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                var raster = (RasterImage)pngImage;

                // Apply gamma correction (example gamma value 2.2)
                raster.AdjustGamma(2.2f);

                // Save the gamma‑corrected image, overwriting the previous PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}