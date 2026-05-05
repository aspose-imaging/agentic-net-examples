using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDir);

            // Define the filters to apply
            var filters = new List<(string Name, Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase Options)>
            {
                ("Median", new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5)),
                ("Bilateral", new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5)),
                ("Gaussian", new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0)),
                ("GaussWiener", new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0)),
                ("MotionWiener", new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0)),
                ("Sharpen", new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0))
            };

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                foreach (var filter in filters)
                {
                    // Load image as RasterImage
                    using (Image image = Image.Load(inputPath))
                    {
                        RasterImage raster = (RasterImage)image;

                        // Measure filter application time
                        var stopwatch = new System.Diagnostics.Stopwatch();
                        stopwatch.Start();
                        raster.Filter(raster.Bounds, filter.Options);
                        stopwatch.Stop();

                        Console.WriteLine($"Applied {filter.Name} filter to {inputPath} in {stopwatch.ElapsedMilliseconds} ms");

                        // Prepare output path and ensure directory exists
                        string outputPath = Path.Combine(outputDir, $"{fileNameWithoutExt}_{filter.Name}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the filtered image as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}