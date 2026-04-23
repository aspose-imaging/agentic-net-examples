using System;
using System.IO;
using System.Diagnostics;
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
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load the high‑resolution PNG
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Measure memory before applying the filter
                long memoryBefore = GC.GetTotalMemory(true);
                Stopwatch sw = Stopwatch.StartNew();

                // Apply a 7×7 Gaussian blur (size 7, sigma 1.0)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(7, 1.0));

                sw.Stop();
                // Measure memory after applying the filter
                long memoryAfter = GC.GetTotalMemory(true);

                // Save the filtered image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);

                // Output benchmark results
                Console.WriteLine($"Filter time: {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"Memory before: {memoryBefore} bytes");
                Console.WriteLine($"Memory after: {memoryAfter} bytes");
                Console.WriteLine($"Memory increase: {memoryAfter - memoryBefore} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}