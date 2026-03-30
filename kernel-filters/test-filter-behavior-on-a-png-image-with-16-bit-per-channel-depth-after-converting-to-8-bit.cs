using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample16bit.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

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
                // Prepare PNG save options: convert to 8‑bit per channel and apply the current filter
                PngOptions saveOptions = new PngOptions
                {
                    BitDepth = 8,                                 // Convert to 8‑bit per channel
                    ColorType = PngColorType.TruecolorWithAlpha, // Keep truecolor with alpha
                    FilterType = filter,
                    CompressionLevel = 9,                         // Max compression (optional)
                    Progressive = true                            // Optional progressive loading
                };

                // Build output file path
                string outputPath = $@"c:\temp\output_{filter}.png";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image with the specified options
                pngImage.Save(outputPath, saveOptions);

                // Optionally, report the file size
                FileInfo info = new FileInfo(outputPath);
                Console.WriteLine($"Filter: {filter}, Output size: {info.Length} bytes");
            }
        }
    }
}