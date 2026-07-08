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
            string outputDir = @"c:\temp\filtered";

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

            // Load the original image once
            using (Image image = Image.Load(inputPath))
            {
                foreach (PngFilterType filter in filterTypes)
                {
                    // Prepare PNG options with the current filter
                    PngOptions options = new PngOptions
                    {
                        FilterType = filter,
                        CompressionLevel = 9, // maximum compression for consistency
                        Progressive = true
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"{filter}.png");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, options);
                        // Write the stream to the file system
                        File.WriteAllBytes(outputPath, ms.ToArray());
                    }

                    // Get size of the filtered image
                    long filteredSize = new FileInfo(outputPath).Length;

                    // Calculate compression ratio (original / filtered)
                    double ratio = (double)originalSize / filteredSize;

                    Console.WriteLine($"Filter: {filter}, Original: {originalSize} bytes, Filtered: {filteredSize} bytes, Ratio: {ratio:F3}");
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
 * 1. When a developer needs to evaluate which PNG filter (None, Up, Sub, Paeth, Avg, Adaptive) yields the smallest file size for web‑optimized images, they can use this code to compare compression ratios.
 * 2. When a SaaS platform stores user‑uploaded PNG assets and wants to minimize storage costs, the code helps determine the most efficient filter setting before saving the image with Aspose.Imaging.
 * 3. When a mobile app generates screenshots and must meet strict bundle size limits, the developer can run this script to measure how each filter impacts the final PNG size.
 * 4. When a CI/CD pipeline validates image assets for a game release, the code can automatically log compression differences to ensure the chosen filter meets quality‑vs‑size requirements.
 * 5. When an e‑commerce site wants to serve high‑resolution product photos with progressive loading, the developer can use this example to compare filter‑based compression and select the optimal setting for faster page loads.
 */