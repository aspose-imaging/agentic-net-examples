using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = "InputImages";
            string outputDir = "OutputImages";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.png");

            // Process each file in parallel – each iteration creates its own filter instance
            System.Threading.Tasks.Parallel.ForEach(inputFiles, inputPath =>
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path and ensure its directory exists
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_sharpened.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply a Sharpen filter, and save the result
                using (Image img = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage raster = (RasterImage)img;

                    // Each thread gets its own filter options instance (thread‑safe)
                    var filter = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0);

                    // Apply the filter to the whole image
                    raster.Filter(raster.Bounds, filter);

                    // Save the processed image
                    raster.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}