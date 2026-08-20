// HOW-TO: Evaluate PNG Filter Types After Converting 16‑Bit to 8‑Bit with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input path
            string inputPath = "C:\\temp\\input16bit.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the 16‑bit PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Define the filter types to evaluate
                PngFilterType[] filterTypes = new PngFilterType[]
                {
                    PngFilterType.None,
                    PngFilterType.Up,
                    PngFilterType.Sub,
                    PngFilterType.Paeth,
                    PngFilterType.Avg,
                    PngFilterType.Adaptive
                };

                foreach (var filter in filterTypes)
                {
                    // Configure PNG save options: convert to 8‑bit and apply the current filter
                    PngOptions options = new PngOptions
                    {
                        BitDepth = 8,                                 // Convert to 8‑bit per channel
                        ColorType = PngColorType.TruecolorWithAlpha, // Preserve alpha channel
                        FilterType = filter,
                        CompressionLevel = 9                         // Maximum compression
                    };

                    // Hard‑coded output path for this filter
                    string outputPath = $"C:\\temp\\output_{filter}.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save to a memory stream to report the resulting file size
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, options);
                        Console.WriteLine($"Filter: {filter}, output size: {ms.Length} bytes");
                    }

                    // Also save the image to disk for manual inspection
                    image.Save(outputPath, options);
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
 * 1. When you need to determine which PNG filter produces the smallest file size after down‑sampling a 16‑bit PNG to 8‑bit using Aspose.Imaging in C#.
 * 2. When you want to verify that alpha transparency is preserved while converting high‑depth PNGs to standard 8‑bit PNGs with different filter settings.
 * 3. When you are optimizing PNG assets for web delivery and must compare compression results of various PNG filters after bit‑depth reduction.
 * 4. When you are debugging an image‑processing pipeline and need to ensure that the selected PNG filter does not corrupt color data during 16‑bit to 8‑bit conversion.
 * 5. When you are building a batch conversion tool that processes 16‑bit PNGs and selects the best filter automatically based on file size or quality metrics.
 */
