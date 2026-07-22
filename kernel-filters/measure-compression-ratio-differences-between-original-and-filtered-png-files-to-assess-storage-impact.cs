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
            string inputPath = @"c:\temp\sample.png";
            string outputDir = @"c:\temp\output\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get original file size
            long originalSize = new FileInfo(inputPath).Length;

            // Define the filter types to test
            PngFilterType[] filterTypes = new PngFilterType[]
            {
                PngFilterType.None,
                PngFilterType.Up,
                PngFilterType.Sub,
                PngFilterType.Paeth,
                PngFilterType.Avg,
                PngFilterType.Adaptive
            };

            // Load the original image once
            using (Image image = Image.Load(inputPath))
            {
                foreach (PngFilterType filter in filterTypes)
                {
                    // Prepare PNG save options
                    PngOptions options = new PngOptions
                    {
                        FilterType = filter,
                        CompressionLevel = 9, // maximum compression
                        Progressive = true   // optional, not required for size measurement
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"{filter}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the current filter
                    image.Save(outputPath, options);

                    // Measure the size of the filtered image
                    long filteredSize = new FileInfo(outputPath).Length;

                    // Compute compression ratio (original / filtered)
                    double ratio = (double)originalSize / filteredSize;

                    // Output the results
                    Console.WriteLine($"Filter: {filter}, Size: {filteredSize} bytes, Ratio: {ratio:F2}");
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
 * 1. When a developer needs to determine which PNG filter (None, Up, Sub, Paeth, Avg, Adaptive) yields the smallest file size for web‑optimized images, they can use this code to compare compression ratios and choose the most storage‑efficient option.
 * 2. When preparing a large set of product photos for an e‑commerce catalog, a developer can run this script to measure how different PNG filter types affect disk usage and select the filter that minimizes bandwidth without sacrificing image quality.
 * 3. When building a mobile app that stores PNG assets locally, a developer can employ this example to evaluate the storage impact of each filter and decide on the optimal compression settings to keep the app size under a target limit.
 * 4. When implementing an automated CI/CD pipeline that validates image assets, a developer can use this code to automatically generate filtered PNG versions, calculate their compression ratios, and fail the build if the size reduction does not meet predefined thresholds.
 * 5. When archiving scientific or medical PNG images for long‑term storage, a developer can run this program to compare filter‑based compression results and document the most space‑saving configuration for compliance and cost‑effectiveness.
 */