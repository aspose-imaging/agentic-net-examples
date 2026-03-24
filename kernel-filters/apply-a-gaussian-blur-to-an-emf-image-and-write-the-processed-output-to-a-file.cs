using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Rasterize EMF to PNG using vector rasterization options
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            emfImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG
        using (Image rasterImage = Image.Load(tempRasterPath))
        {
            // Cast to RasterImage to apply filters
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur to the whole image
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, blurOptions);

            // Save the blurred image to the final output path
            raster.Save(outputPath);
        }

        // Optionally delete the temporary raster file
        try
        {
            File.Delete(tempRasterPath);
        }
        catch
        {
            // Ignored – cleanup failure should not stop the program
        }
    }
}