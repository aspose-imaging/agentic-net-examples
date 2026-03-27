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
        string inputPath = "sample.otg";
        string outputPath = "result.bmp";

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
            // Configure rasterization options with white background
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = image.Size
            };

            // Set up BMP save options and attach rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}