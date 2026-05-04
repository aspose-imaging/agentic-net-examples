using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string rasterOutputPath = @"C:\Images\sample.bmp";
            string binaryOutputPath = @"C:\Images\sample_binary.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rasterOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath));

            // Load ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Rasterize ODG to BMP
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };
                odgImage.Save(rasterOutputPath, bmpOptions);
            }

            // Load the rasterized BMP as a RasterImage
            using (Image bmpImage = Image.Load(rasterOutputPath))
            {
                // Cast to RasterImage to access BinarizeOtsu
                var raster = (RasterImage)bmpImage;

                // Apply Otsu threshold to create binary image
                raster.BinarizeOtsu();

                // Save the binary image
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 1 // 1-bit per pixel for binary image
                };
                raster.Save(binaryOutputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}