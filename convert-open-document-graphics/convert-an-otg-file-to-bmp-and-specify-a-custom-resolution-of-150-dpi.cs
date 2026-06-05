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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.bmp";

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
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // Set up BMP save options with the rasterization settings
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save the image as BMP
                otgImage.Save(outputPath, bmpOptions);
            }

            // Load the saved BMP to adjust its resolution
            using (BmpImage bmpImage = (BmpImage)Image.Load(outputPath))
            {
                // Set custom resolution to 150 DPI
                bmpImage.SetResolution(150.0, 150.0);

                // Overwrite the BMP file with the new resolution
                bmpImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}