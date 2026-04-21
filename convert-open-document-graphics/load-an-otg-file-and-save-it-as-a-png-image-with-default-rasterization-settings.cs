using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.otg";
        string outputPath = "output\\sample.png";

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
            // Prepare PNG save options with default rasterization settings
            PngOptions pngOptions = new PngOptions();

            // Configure rasterization options for OTG
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Use the source image size as the page size
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}