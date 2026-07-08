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
            string inputPath = @"C:\temp\sample16bit.png";
            string outputDir = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

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

            // Load the 16‑bit PNG image
            using (Image image = Image.Load(inputPath))
            {
                foreach (PngFilterType filter in filterTypes)
                {
                    // Prepare PNG save options: convert to 8‑bit and set filter type
                    PngOptions options = new PngOptions
                    {
                        BitDepth = 8,                     // Convert to 8‑bit per channel
                        FilterType = filter,              // Current filter type
                        ColorType = PngColorType.TruecolorWithAlpha,
                        CompressionLevel = 9,
                        Progressive = true
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"filter_{filter}.png");

                    // Ensure the directory for this file exists (covers subfolders if any)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    image.Save(outputPath, options);

                    // Report the resulting file size
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
 * 1. When a developer needs to evaluate how each PNG filter type (None, Up, Sub, Paeth, Avg, Adaptive) impacts file size and visual fidelity after converting a 16‑bit PNG to an 8‑bit image for web optimization, they can use this code.
 * 2. When a developer wants to verify that the Aspose.Imaging library correctly preserves alpha transparency while down‑sampling high‑depth PNGs and applying different filter algorithms for progressive rendering, this example provides a quick test.
 * 3. When a developer is troubleshooting compression artifacts in medical or scientific images that must be reduced from 16‑bit to 8‑bit before archival, the code helps compare filter effects on image quality.
 * 4. When a developer is building an automated pipeline that generates multiple PNG variants with different filter settings to select the best trade‑off between compression level and decoding speed on client devices, this snippet demonstrates the required steps.
 * 5. When a developer needs to confirm that the chosen PNG filter works consistently across various output directories and file‑system permissions while converting high‑depth images, the example offers a practical validation routine.
 */