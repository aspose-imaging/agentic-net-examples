using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

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
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size // preserve original size
            };
            pngOptions.VectorRasterizationOptions = otgRasterOptions;

            // Rasterize OTG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                otgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // reset stream for reading

                // Load the rasterized PNG image
                using (Image pngImage = Image.Load(memoryStream))
                {
                    // Apply gamma correction (example gamma = 2.2)
                    if (pngImage is RasterImage raster)
                    {
                        raster.AdjustGamma(2.2f);
                        // Save the final PNG with gamma applied
                        raster.Save(outputPath);
                    }
                }
            }
        }
    }
}