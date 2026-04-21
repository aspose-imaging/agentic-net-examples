using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/sample.otg";
        string outputPath = "output/sample.bmp";

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
            // Set up rasterization options to preserve vector content
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options (default compression supports transparency)
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save as BMP while preserving transparency
            image.Save(outputPath, bmpOptions);
        }
    }
}