using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_converted.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    // Preserve the original size
                    PageSize = odgImage.Size
                };

                // Prepare BMP save options and attach rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the ODG as BMP (initial resolution may be default)
                odgImage.Save(outputPath, bmpOptions);
            }

            // Re-open the saved BMP to set the desired resolution (150 DPI)
            using (Image bmpImage = Image.Load(outputPath))
            {
                var bmp = (BmpImage)bmpImage;
                bmp.SetResolution(150.0, 150.0);
                // Overwrite the file with the new resolution
                bmp.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}