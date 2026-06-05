using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_binary.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage for rasterization options
                OdgImage odgImage = (OdgImage)image;

                // Set up rasterization options for BMP output
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                };

                // BMP save options using the rasterization settings
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                odgImage.Save(outputPath, bmpOptions);
            }

            // Load the saved BMP to apply binary threshold
            using (Image bmpImage = Image.Load(outputPath))
            {
                // Cast to RasterImage to access BinarizeOtsu
                RasterImage raster = (RasterImage)bmpImage;

                // Apply Otsu thresholding to create a binary image
                raster.BinarizeOtsu();

                // Save the binary image (overwrites the previous BMP)
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}