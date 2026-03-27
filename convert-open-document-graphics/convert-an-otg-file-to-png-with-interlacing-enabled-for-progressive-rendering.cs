using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for OTG to PNG conversion
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };

            // Configure PNG options with progressive (interlaced) encoding
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions,
                Progressive = true
            };

            // Save the image as PNG with interlacing enabled
            image.Save(outputPath, pngOptions);
        }
    }
}