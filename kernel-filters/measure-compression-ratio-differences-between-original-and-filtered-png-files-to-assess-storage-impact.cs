// HOW-TO: Compare PNG Filter Types Compression Ratio In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputDir = @"C:\temp\output\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Get original file size
            long originalSize = new FileInfo(inputPath).Length;

            // Define filter types to test
            PngFilterType[] filterTypes = new PngFilterType[]
            {
                PngFilterType.None,
                PngFilterType.Up,
                PngFilterType.Sub,
                PngFilterType.Paeth,
                PngFilterType.Avg,
                PngFilterType.Adaptive
            };

            foreach (PngFilterType filterType in filterTypes)
            {
                // Load the original image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PNG options with the current filter
                    PngOptions options = new PngOptions
                    {
                        FilterType = filterType,
                        CompressionLevel = 9, // maximum compression
                        Progressive = true   // optional, enables progressive loading
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"sample_{filterType}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    image.Save(outputPath, options);

                    // Measure the size of the filtered PNG
                    long filteredSize = new FileInfo(outputPath).Length;

                    // Compute compression ratio relative to the original
                    double ratio = (double)filteredSize / originalSize;

                    Console.WriteLine($"Filter: {filterType}, Size: {filteredSize} bytes, Ratio: {ratio:F3}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to determine which PNG filter yields the smallest file size for archival storage.
 * 2. When you want to evaluate the impact of different PNG filters on bandwidth usage for web delivery.
 * 3. When you are optimizing image assets for mobile apps and must choose the most space‑efficient filter.
 * 4. When you need to generate a report of compression savings after applying various PNG filters in a batch process.
 * 5. When you are comparing progressive versus non‑progressive PNG outputs to decide on the best format for lazy loading.
 */
