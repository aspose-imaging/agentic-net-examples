using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for OTG
            var otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // Configure BMP save options with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the image as BMP
            otgImage.Save(outputPath, bmpOptions);
        }

        // Ensure output directory exists before second save (redundant but follows rule)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the saved BMP to adjust its resolution
        using (Image bmpImage = Image.Load(outputPath))
        {
            var bmp = (BmpImage)bmpImage;
            // Set custom resolution to 150 DPI
            bmp.SetResolution(150.0, 150.0);
            // Overwrite the BMP with the new resolution
            bmp.Save(outputPath);
        }
    }
}