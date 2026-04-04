using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Adjust brightness
            TiffImage tiff = (TiffImage)image;
            tiff.AdjustBrightness(50);

            // Apply Gaussian blur
            RasterImage raster = (RasterImage)image;
            var blurOptions = new GaussianBlurFilterOptions
            {
                Radius = 5,
                Sigma = 1.5f
            };
            raster.Filter(raster.Bounds, blurOptions);

            // Save the result as PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}