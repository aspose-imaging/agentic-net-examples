using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (first argument) or default sample image.
        string inputPath = args.Length > 0 ? args[0] : "sample.png";

        // Output directory (second argument) or default "output".
        string outputDir = args.Length > 1 ? args[1] : "output";
        Directory.CreateDirectory(outputDir);

        // Define the set of filters to apply with their descriptive names.
        var filters = new (string Name, FilterOptionsBase Options)[]
        {
            ("Median", new MedianFilterOptions(5)),
            ("BilateralSmoothing", new BilateralSmoothingFilterOptions(5)),
            ("GaussianBlur", new GaussianBlurFilterOptions(5, 4.0)),
            ("GaussWiener", new GaussWienerFilterOptions(5, 4.0)),
            ("MotionWiener", new MotionWienerFilterOptions(10, 1.0, 90.0)),
            ("Sharpen", new SharpenFilterOptions(5, 4.0))
        };

        // Apply each filter independently and save the result.
        foreach (var (name, options) in filters)
        {
            // Load the source image as a RasterImage.
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply the filter to the whole image bounds.
                raster.Filter(raster.Bounds, options);

                // Construct output file name.
                string outputPath = Path.Combine(outputDir,
                    $"{Path.GetFileNameWithoutExtension(inputPath)}_{name}.png");

                // Save the processed image as PNG.
                raster.Save(outputPath, new PngOptions());
            }
        }
    }
}