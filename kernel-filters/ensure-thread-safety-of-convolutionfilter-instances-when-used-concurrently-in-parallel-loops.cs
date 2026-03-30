using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input files
        var inputFiles = new List<string>
        {
            @"C:\Images\Input1.png",
            @"C:\Images\Input2.png",
            @"C:\Images\Input3.png"
        };

        // Output directory (hardcoded)
        string outputDir = @"C:\Images\Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Process images in parallel
        System.Threading.Tasks.Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + "_filtered.png");

            // Ensure output directory exists (unconditional as per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, apply filter, and save
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Each thread creates its own filter options instance (thread‑safe)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);

                // Apply filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the filtered image
                rasterImage.Save(outputPath);
            }
        });
    }
}