using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string rasterPath = @"C:\Images\output.bmp";
            string binaryPath = @"C:\Images\output_binary.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(binaryPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for vector to raster conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };

                // BMP save options with the rasterization settings
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the rasterized image as BMP
                otgImage.Save(rasterPath, bmpOptions);
            }

            // Load the rasterized BMP image
            using (Image bmpImage = Image.Load(rasterPath))
            {
                // Cast to RasterImage to access BinarizeOtsu
                var raster = (RasterImage)bmpImage;

                // Apply Otsu thresholding to obtain a binary image
                raster.BinarizeOtsu();

                // Save the binary image as BMP
                var bmpOptions = new BmpOptions(); // default BMP options
                raster.Save(binaryPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}