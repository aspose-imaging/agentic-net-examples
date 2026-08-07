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
            string inputPath = @"C:\temp\input16bit.png";
            string outputDir = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

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

            // Load the 16‑bit PNG image
            using (Image image = Image.Load(inputPath))
            {
                foreach (PngFilterType filter in filterTypes)
                {
                    // Configure PNG save options: convert to 8‑bit and set filter type
                    PngOptions options = new PngOptions
                    {
                        BitDepth = 8,
                        FilterType = filter,
                        // Preserve color type (Truecolor with alpha works for 16‑bit source)
                        ColorType = PngColorType.TruecolorWithAlpha,
                        // Optional: enable progressive loading
                        Progressive = true
                    };

                    // Save to a memory stream to obtain the output size
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, options);
                        long size = ms.Length;

                        // Build output file path
                        string outputPath = Path.Combine(outputDir, $"output_{filter}.png");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Write the stream contents to the file
                        File.WriteAllBytes(outputPath, ms.ToArray());

                        Console.WriteLine($"Filter: {filter}, Output size: {size} bytes, Saved to: {outputPath}");
                    }
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
 * 1. When a developer needs to compare how different PNG filter types affect the file size after down‑sampling a 16‑bit per channel image to 8‑bit for web delivery, they can use this code.
 * 2. When optimizing a high‑dynamic‑range PNG for mobile apps, the code lets you test each PngFilterType to choose the smallest 8‑bit output while preserving transparency.
 * 3. When troubleshooting visual artifacts that appear after converting 16‑bit medical scans to 8‑bit PNG, the sample shows how to apply each filter and inspect the resulting stream size.
 * 4. When building an automated image‑processing pipeline in C# that must generate progressive PNGs from 16‑bit sources, this snippet demonstrates setting the Progressive flag and evaluating filter impact.
 * 5. When creating a quality‑control tool that validates that 16‑bit PNG assets are correctly reduced to 8‑bit with the appropriate filter before uploading to a CDN, the example provides the necessary Aspose.Imaging operations.
 */