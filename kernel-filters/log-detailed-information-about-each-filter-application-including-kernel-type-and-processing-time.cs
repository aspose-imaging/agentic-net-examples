using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path
            string inputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output directory
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Define filters to apply
            var filters = new (string Name, Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase Options)[]
            {
                ("GaussianBlur", new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0)),
                ("Sharpen", new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0)),
                ("Median", new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5)),
                ("Bilateral", new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5))
            };

            foreach (var filter in filters)
            {
                // Load image fresh for each filter to avoid cumulative effects
                using (Image image = Image.Load(inputPath))
                {
                    var raster = (RasterImage)image;

                    // Measure processing time
                    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    raster.Filter(raster.Bounds, filter.Options);
                    stopwatch.Stop();

                    // Retrieve kernel type information if available
                    string kernelInfo = "N/A";
                    var kernelProp = filter.Options.GetType().GetProperty("Kernel");
                    if (kernelProp != null)
                    {
                        var kernel = kernelProp.GetValue(filter.Options);
                        kernelInfo = kernel?.GetType().Name ?? "null";
                    }

                    // Save the filtered image
                    string outputPath = Path.Combine(outputDir, $"sample_{filter.Name}.png");
                    // Ensure directory exists (already created above)
                    raster.Save(outputPath, new PngOptions());

                    // Log details
                    Console.WriteLine($"{filter.Name} filter applied. Kernel: {kernelInfo}. Time: {stopwatch.ElapsedMilliseconds} ms.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}