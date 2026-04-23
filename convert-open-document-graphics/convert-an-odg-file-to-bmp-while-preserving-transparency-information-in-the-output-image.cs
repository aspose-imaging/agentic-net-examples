using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP options – default compression (Bitfields) preserves transparency
            BmpOptions bmpOptions = new BmpOptions();

            // Set rasterization options for vector ODG content
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                // Transparent background to keep alpha channel
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                // Preserve original image size
                PageSize = image.Size
            };

            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as BMP with transparency
            image.Save(outputPath, bmpOptions);
        }
    }
}