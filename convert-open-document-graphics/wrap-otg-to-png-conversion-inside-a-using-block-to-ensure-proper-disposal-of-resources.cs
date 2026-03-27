using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\Result\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image and convert it to PNG inside a using block
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with OTG rasterization settings
            var pngOptions = new PngOptions();
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Preserve the original image size
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = otgRasterOptions;

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}