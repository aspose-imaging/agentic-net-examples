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
        string intermediatePath = @"C:\Images\intermediate.bmp";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for intermediate and final output exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) file and export it to a BMP file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            BmpOptions bmpExportOptions = new BmpOptions();
            cdrImage.Save(intermediatePath, bmpExportOptions);
        }

        // Load the intermediate BMP as a raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(intermediatePath))
        {
            // Apply Gaussian blur filter to the entire image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image as BMP
            BmpOptions bmpSaveOptions = new BmpOptions();
            rasterImage.Save(outputPath, bmpSaveOptions);
        }
    }
}