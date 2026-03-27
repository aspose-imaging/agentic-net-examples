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
        string inputPath = "input\\sample.odg";
        string outputPath = "output\\sample.bmp";
        string binaryOutputPath = "output\\sample_binary.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG to BMP conversion
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };

            // Configure BMP save options with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP
            odgImage.Save(outputPath, bmpOptions);
        }

        // Load the saved BMP image as a raster image
        using (Image bmpImage = Image.Load(outputPath))
        {
            // Cast to RasterImage to access binarization methods
            var rasterImage = (RasterImage)bmpImage;

            // Apply Otsu thresholding to create a binary image
            rasterImage.BinarizeOtsu();

            // Save the binary image
            rasterImage.Save(binaryOutputPath);
        }
    }
}