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
        string outputDir = @"C:\temp\output\";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the 16‑bit PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Iterate over all available PNG filter types
                foreach (PngFilterType filter in Enum.GetValues(typeof(PngFilterType)))
                {
                    // Prepare PNG save options: convert to 8‑bit and apply the current filter
                    PngOptions saveOptions = new PngOptions
                    {
                        BitDepth = 8,                                 // Convert to 8‑bit per channel
                        FilterType = filter,                          // Current filter type
                        ColorType = PngColorType.TruecolorWithAlpha, // Preserve alpha channel
                        CompressionLevel = 9,                         // Maximum compression
                        Progressive = false                           // No progressive loading needed for this test
                    };

                    // Build output file path and ensure its directory exists
                    string outputPath = Path.Combine(outputDir, $"output_{filter}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);

                    // Report the resulting file size
                    long fileSize = new FileInfo(outputPath).Length;
                    Console.WriteLine($"Filter {filter}: output size {fileSize} bytes.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}