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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

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

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    image.Save(outputPath, options);

                    // Get size of the filtered file
                    long filteredSize = new FileInfo(outputPath).Length;

                    // Calculate compression ratio (original / filtered)
                    double ratio = (double)originalSize / filteredSize;

                    // Output the results
                    Console.WriteLine($"Filter: {filter}, Output Size: {filteredSize} bytes, Compression Ratio: {ratio:F2}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}