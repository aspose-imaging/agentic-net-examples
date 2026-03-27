using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.bmp";

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
            // Prepare BMP save options (default compression Bitfields preserves transparency)
            var bmpOptions = new BmpOptions();

            // Configure rasterization options for OTG vector content
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };
            bmpOptions.VectorRasterizationOptions = otgRasterizationOptions;

            // Save the image as BMP while keeping transparency
            image.Save(outputPath, bmpOptions);
        }
    }
}