using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input16bit.png";
        string outputDir = @"C:\temp\filter_test";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the 16‑bit PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
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

                foreach (PngFilterType filter in filterTypes)
                {
                    // Prepare PNG save options: convert to 8‑bit and set filter
                    PngOptions saveOptions = new PngOptions
                    {
                        BitDepth = 8,                                   // Convert to 8‑bit per channel
                        ColorType = PngColorType.TruecolorWithAlpha,    // Preserve alpha if present
                        FilterType = filter,
                        CompressionLevel = 9,                           // Max compression for size comparison
                        Progressive = true
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"output_{filter}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the current filter
                    pngImage.Save(outputPath, saveOptions);

                    // Report file size
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