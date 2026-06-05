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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample_converted.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9, // maximum compression
                    // Enable progressive loading (optional but common for PNG)
                    Progressive = true
                };

                // Configure rasterization options for vector OTG content
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original dimensions
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

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