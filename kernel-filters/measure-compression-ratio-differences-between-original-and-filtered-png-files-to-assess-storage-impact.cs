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
            // Hardcoded input PNG file
            string inputPath = @"C:\temp\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Get original file size
            long originalSize = new FileInfo(inputPath).Length;

            // Output directory for filtered images
            string outputDir = @"C:\temp\filtered";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Define filter types to evaluate
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
                // Prepare output file path
                string outputPath = Path.Combine(outputDir, $"sample_{filter}.png");

                // Ensure directory for this output (redundant but follows rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load original image
                using (Image image = Image.Load(inputPath))
                {
                    // Set PNG options with the current filter
                    PngOptions options = new PngOptions
                    {
                        FilterType = filter,
                        // Keep other options default; you may set CompressionLevel if desired
                    };

                    // Save image with specified filter
                    image.Save(outputPath, options);
                }

                // Get size of filtered image
                long filteredSize = new FileInfo(outputPath).Length;

                // Calculate compression ratio (original / filtered)
                double ratio = (double)originalSize / filteredSize;

                Console.WriteLine($"Filter: {filter}, Original: {originalSize} bytes, Filtered: {filteredSize} bytes, Ratio: {ratio:F3}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}