using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Temp\input.cdr";
        string outputPath = @"C:\Temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // The filter works on RasterImage, so cast accordingly
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            // Apply a Gauss‑Wiener deconvolution filter (a concrete Deconvolution filter)
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}