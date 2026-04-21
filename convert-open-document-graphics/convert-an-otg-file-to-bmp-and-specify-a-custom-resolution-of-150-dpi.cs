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
        string outputPath = @"C:\Images\Result\sample.bmp";

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
            // Prepare rasterization options for OTG conversion
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size // Preserve original size
            };

            // Set up BMP save options with vector rasterization
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions
            };

            // Save the OTG as BMP (initial resolution)
            otgImage.Save(outputPath, bmpOptions);
        }

        // Load the newly created BMP to adjust resolution
        using (Image bmpImageBase = Image.Load(outputPath))
        {
            // Cast to BmpImage to access SetResolution
            if (bmpImageBase is BmpImage bmpImage)
            {
                // Set custom resolution to 150 DPI
                bmpImage.SetResolution(150.0, 150.0);

                // Ensure output directory exists (again, safe)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Overwrite the BMP with the new resolution
                bmpImage.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("Failed to cast loaded image to BmpImage.");
            }
        }
    }
}