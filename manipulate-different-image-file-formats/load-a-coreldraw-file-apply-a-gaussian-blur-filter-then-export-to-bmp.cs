using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string intermediatePath = @"C:\Images\temp.bmp";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Save the vector image to a temporary BMP file (unfiltered)
            cdrImage.Save(intermediatePath, new BmpOptions());
        }

        // Load the temporary BMP as a raster image
        using (Image bmpImage = Image.Load(intermediatePath))
        {
            // Cast to RasterImage to access filtering capabilities
            var rasterImage = (RasterImage)bmpImage;

            // Apply Gaussian blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as BMP to the final output path
            rasterImage.Save(outputPath, new BmpOptions());
        }
    }
}