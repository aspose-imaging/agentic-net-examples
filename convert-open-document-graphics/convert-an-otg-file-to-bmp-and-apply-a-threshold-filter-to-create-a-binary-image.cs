using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string bmpOutputPath = @"C:\Images\sample.bmp";
        string binaryOutputPath = @"C:\Images\sample_binary.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist before any save operation
        Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for vector to raster conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size // preserve original dimensions
            };

            // Set BMP save options and attach rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the rasterized image as BMP
            otgImage.Save(bmpOutputPath, bmpOptions);
        }

        // Load the generated BMP as a raster image
        using (Image bmpImage = Image.Load(bmpOutputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            if (bmpImage is RasterImage rasterImage)
            {
                // Apply Otsu threshold binarization
                rasterImage.BinarizeOtsu();

                // Save the binary image as BMP
                rasterImage.Save(binaryOutputPath);
            }
        }
    }
}