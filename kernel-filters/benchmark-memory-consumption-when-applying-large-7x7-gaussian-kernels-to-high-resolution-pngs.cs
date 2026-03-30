using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\highres.png";
        string outputPath = @"C:\Images\highres_gaussian.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Record initial memory usage
        long memoryBefore = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;
        long gcMemoryBefore = GC.GetTotalMemory(forceFullCollection: true);

        // Load the high‑resolution PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering
            RasterImage rasterImage = (RasterImage)image;

            // Prepare Gaussian blur filter with a 7x7 kernel
            // Size must be odd; sigma chosen as 2.0 for noticeable blur
            var gaussianOptions = new GaussianBlurFilterOptions(7, 2.0);

            // Benchmark the filter operation
            Stopwatch sw = Stopwatch.StartNew();
            rasterImage.Filter(rasterImage.Bounds, gaussianOptions);
            sw.Stop();

            // Save the processed image
            rasterImage.Save(outputPath);

            // Output timing information
            Console.WriteLine($"Gaussian blur applied in {sw.ElapsedMilliseconds} ms");
        }

        // Record final memory usage
        long memoryAfter = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;
        long gcMemoryAfter = GC.GetTotalMemory(forceFullCollection: true);

        // Report memory consumption
        Console.WriteLine($"Allocated memory (Aspose cache) before: {memoryBefore} bytes");
        Console.WriteLine($"Allocated memory (Aspose cache) after : {memoryAfter} bytes");
        Console.WriteLine($"GC total memory before: {gcMemoryBefore} bytes");
        Console.WriteLine($"GC total memory after : {gcMemoryAfter} bytes");
    }
}