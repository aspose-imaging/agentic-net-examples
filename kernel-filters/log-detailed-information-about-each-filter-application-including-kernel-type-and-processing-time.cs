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
            // Hardcoded input and output paths
            string inputPath = "input.png";

            // Ensure input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Base output directory
            string outputDir = "output";
            Directory.CreateDirectory(outputDir); // unconditional as per requirements

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // ---------- Gaussian Blur ----------
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
                LogAndApplyFilter(raster, gaussianOptions, Path.Combine(outputDir, "gaussian.png"));

                // ---------- Sharpen ----------
                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0);
                LogAndApplyFilter(raster, sharpenOptions, Path.Combine(outputDir, "sharpen.png"));

                // ---------- Median ----------
                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5);
                LogAndApplyFilter(raster, medianOptions, Path.Combine(outputDir, "median.png"));

                // ---------- Bilateral Smoothing ----------
                var bilateralOptions = new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5);
                LogAndApplyFilter(raster, bilateralOptions, Path.Combine(outputDir, "bilateral.png"));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to log kernel type, processing time and save the image
    static void LogAndApplyFilter(RasterImage raster, Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase options, string outputPath)
    {
        // Log kernel type (if available)
        string kernelInfo = "None";
        try
        {
            var kernelProp = options.GetType().GetProperty("Kernel");
            if (kernelProp != null)
            {
                var kernel = kernelProp.GetValue(options);
                kernelInfo = kernel?.GetType().Name ?? "None";
            }
        }
        catch { /* ignore reflection errors */ }

        Console.WriteLine($"Applying {options.GetType().Name} (Kernel: {kernelInfo})");

        // Measure processing time
        DateTime start = DateTime.Now;
        raster.Filter(raster.Bounds, options);
        DateTime end = DateTime.Now;
        TimeSpan duration = end - start;
        Console.WriteLine($"Processing time: {duration.TotalMilliseconds} ms");

        // Ensure output directory exists (already created in Main, but called as per rule)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Save the result as PNG
        raster.Save(outputPath, new PngOptions());
        Console.WriteLine($"Saved output to {outputPath}");
    }
}