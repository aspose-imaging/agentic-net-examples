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

            // Ensure output directory exists (Directory.CreateDirectory works even if the directory already exists)
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
                    // Configure PNG save options
                    PngOptions options = new PngOptions
                    {
                        FilterType = filter,
                        CompressionLevel = 9,          // maximum compression
                        Progressive = true,
                        ColorType = PngColorType.TruecolorWithAlpha,
                        BitDepth = 8
                    };

                    // Save to memory stream to obtain size without writing to disk
                    long filteredSize;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, options);
                        filteredSize = ms.Length;
                    }

                    // Save to file for inspection
                    string outputPath = Path.Combine(outputDir, $"{filter}.png");
                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, options);

                    // Compute compression ratio (filtered/original)
                    double ratio = (double)filteredSize / originalSize;

                    Console.WriteLine($"Filter: {filter}, Size: {filteredSize} bytes, Ratio: {ratio:P2}");
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
 * 1. When a web developer wants to choose the optimal PNG filter to minimize bandwidth for high‑traffic image assets, they can run this code to compare original and filtered file sizes and select the most efficient setting.
 * 2. When a mobile app team needs to reduce the app bundle size by compressing UI icons, they can use the code to evaluate how different PngFilterType options affect storage consumption on the device.
 * 3. When a cloud‑based image storage service wants to estimate cost savings from applying maximum compression with various PNG filters, the snippet provides a quick way to measure the compression ratio for each filter.
 * 4. When a digital archivist is preserving large collections of PNG photographs and must balance quality with archival storage limits, the program helps determine which filter yields the smallest file without altering color depth.
 * 5. When a CI/CD pipeline includes automated image optimization checks, developers can integrate this code to automatically verify that newly added PNG assets meet predefined compression‑ratio thresholds before deployment.
 */