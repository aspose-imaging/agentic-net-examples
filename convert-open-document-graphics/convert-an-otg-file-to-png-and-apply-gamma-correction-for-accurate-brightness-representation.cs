using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\Result\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare PNG save options with OTG rasterization settings
            var pngOptions = new PngOptions();
            var otgRaster = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = otgImage.Size
            };
            pngOptions.VectorRasterizationOptions = otgRaster;

            // Save the rasterized image as PNG
            otgImage.Save(outputPath, pngOptions);
        }

        // Load the generated PNG to apply gamma correction
        using (Image pngImage = Image.Load(outputPath))
        {
            // Cast to RasterImage to access AdjustGamma
            var raster = (RasterImage)pngImage;

            // Apply gamma correction (example gamma value)
            raster.AdjustGamma(2.2f);

            // Ensure the output directory exists (redundant but follows the rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Overwrite the PNG with gamma‑corrected data
            pngImage.Save(outputPath);
        }
    }
}