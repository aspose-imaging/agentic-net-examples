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

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                // Set a background color (e.g., white)
                BackgroundColor = Color.White,
                // Preserve original page size
                PageSize = image.Size
            };

            // Set up PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}