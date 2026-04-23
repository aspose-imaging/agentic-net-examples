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
        string outputPath = @"C:\Images\output\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image and convert it to PNG
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set PNG save options with the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}