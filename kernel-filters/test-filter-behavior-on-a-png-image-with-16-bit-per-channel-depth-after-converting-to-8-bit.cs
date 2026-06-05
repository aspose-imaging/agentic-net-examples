using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folder paths
            string inputPath = @"C:\temp\sample16bit.png";
            string outputFolder = @"C:\temp\filter_test";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Load the 16‑bit PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
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

                foreach (PngFilterType filter in filterTypes)
                {
                    // Prepare PNG save options: convert to 8‑bit and set the current filter
                    PngOptions saveOptions = new PngOptions
                    {
                        BitDepth = 8,                 // Convert to 8‑bit per channel
                        FilterType = filter,
                        // Preserve other defaults (e.g., compression level)
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputFolder, $"output_{filter}.png");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    pngImage.Save(outputPath, saveOptions);

                    // Report the file size for this filter type
                    long fileSize = new FileInfo(outputPath).Length;
                    Console.WriteLine($"Filter: {filter}, Output size: {fileSize} bytes");
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
 * 1. When a developer needs to compare how different PNG filter types affect the visual quality and file size of a 16‑bit image after down‑sampling it to 8‑bit for web delivery.
 * 2. When a developer wants to verify that the Aspose.Imaging PNG encoder correctly applies each filter (None, Up, Sub, Paeth, Avg, Adaptive) while converting high‑dynamic‑range PNGs to standard 8‑bit PNGs for mobile apps.
 * 3. When a developer is troubleshooting compression artifacts in medical imaging scans that must be saved as 8‑bit PNGs and needs to test which filter yields the least data loss.
 * 4. When a developer is building an automated image‑processing pipeline that must generate multiple PNG variants with different filters to determine the optimal setting for archival storage.
 * 5. When a developer is creating a quality‑control script to ensure that legacy 16‑bit PNG assets are correctly down‑converted and that each PNG filter type produces a valid, viewable 8‑bit file before publishing.
 */