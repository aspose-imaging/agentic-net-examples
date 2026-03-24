using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.psd";
        string outputPath = @"C:\Images\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = image as RasterImage;
            if (rasterImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a raster image and cannot be processed.");
                return;
            }

            // Apply a Gaussian deconvolution filter (Gauss-Wiener) to the whole image
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image as PSD
            var saveOptions = new PsdOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}