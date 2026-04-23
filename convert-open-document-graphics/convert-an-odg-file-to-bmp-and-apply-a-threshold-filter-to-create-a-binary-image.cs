using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample.bmp";
        string binaryOutputPath = "sample_binary.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath) ?? string.Empty);

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare BMP save options with rasterization settings for ODG
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.VectorRasterizationOptions = new OdgRasterizationOptions
            {
                // Use the original image size for rasterization
                PageSize = odgImage.Size
            };

            // Save the rasterized BMP
            odgImage.Save(outputPath, bmpOptions);
        }

        // Load the rasterized BMP as a RasterImage to apply thresholding
        using (Image bmpImage = Image.Load(outputPath))
        {
            // Cast to RasterImage to access BinarizeOtsu
            RasterImage raster = (RasterImage)bmpImage;

            // Apply Otsu thresholding to create a binary image
            raster.BinarizeOtsu();

            // Save the binary image
            raster.Save(binaryOutputPath);
        }
    }
}