using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
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
                // Configure rasterization options for OTG
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = otgImage.Size
                };

                // Set up BMP save options and attach rasterization options
                BmpOptions bmpSaveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save as BMP (initial resolution may be default)
                otgImage.Save(outputPath, bmpSaveOptions);
            }

            // Re-open the saved BMP to set custom resolution (150 DPI)
            using (BmpImage bmpImage = new BmpImage(outputPath))
            {
                bmpImage.SetResolution(150.0, 150.0);
                // Overwrite the file with the new resolution
                bmpImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}