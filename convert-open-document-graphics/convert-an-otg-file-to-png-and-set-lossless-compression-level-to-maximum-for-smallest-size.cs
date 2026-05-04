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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with maximum compression
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9,          // Max compression (0-9)
                    Progressive = true            // Optional: enable progressive loading
                };

                // Set rasterization options for vector OTG source
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size          // Preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}