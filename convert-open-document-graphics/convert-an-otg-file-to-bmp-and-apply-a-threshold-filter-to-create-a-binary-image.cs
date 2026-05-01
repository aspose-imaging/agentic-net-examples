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
            string rasterizedPath = @"C:\Images\sample.bmp";
            string binaryPath = @"C:\Images\sample_binary.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rasterizedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(binaryPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare BMP save options with OTG rasterization settings
                BmpOptions bmpOptions = new BmpOptions();
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };
                bmpOptions.VectorRasterizationOptions = otgRasterization;

                // Save the rasterized image as BMP
                otgImage.Save(rasterizedPath, bmpOptions);
            }

            // Load the rasterized BMP for binarization
            using (Image bmpImage = Image.Load(rasterizedPath))
            {
                // Cast to RasterImage to access BinarizeOtsu
                if (bmpImage is RasterImage rasterImage)
                {
                    // Apply Otsu thresholding to create a binary image
                    rasterImage.BinarizeOtsu();

                    // Save the binary BMP
                    rasterImage.Save(binaryPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}