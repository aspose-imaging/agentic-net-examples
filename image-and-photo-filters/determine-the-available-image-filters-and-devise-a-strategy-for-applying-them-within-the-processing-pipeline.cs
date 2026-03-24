using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputDir = @"c:\temp\processed";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Define a list of filter options to apply
            var filters = new (string suffix, FilterOptionsBase options)[]
            {
                ("Median", new MedianFilterOptions(5)),
                ("Bilateral", new BilateralSmoothingFilterOptions(5)),
                ("GaussianBlur", new GaussianBlurFilterOptions(5, 4.0)),
                ("GaussWiener", new GaussWienerFilterOptions(5, 4.0)),
                ("MotionWiener", new MotionWienerFilterOptions(10, 1.0, 90.0)),
                ("Sharpen", new SharpenFilterOptions(5, 4.0))
            };

            // Apply each filter sequentially and save the result
            foreach (var (suffix, options) in filters)
            {
                // Apply filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, options);

                // Build output file path
                string outputPath = Path.Combine(outputDir, $"sample.{suffix}.png");

                // Ensure the directory for the output file exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image
                rasterImage.Save(outputPath);
            }
        }
    }
}