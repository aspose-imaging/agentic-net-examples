using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Gaussian blur, and save as BigTIFF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Configure BigTIFF save options
            var bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            bigTiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            bigTiffOptions.Compression = TiffCompressions.Lzw;
            bigTiffOptions.Photometric = TiffPhotometrics.Rgb;
            bigTiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Save the processed image as a BigTIFF file
            raster.Save(outputPath, bigTiffOptions);
        }
    }
}