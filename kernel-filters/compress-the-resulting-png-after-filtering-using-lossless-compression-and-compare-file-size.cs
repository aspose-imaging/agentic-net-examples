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
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Report original file size
                long originalSize = new FileInfo(inputPath).Length;
                Console.WriteLine($"Original size: {originalSize} bytes");

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

                // Iterate over each filter, save with maximal lossless compression, and report size
                foreach (PngFilterType filter in filterTypes)
                {
                    var options = new PngOptions
                    {
                        CompressionLevel = 9,          // maximal lossless compression
                        FilterType = filter,
                        Progressive = true
                    };

                    string outputPath = Path.Combine(outputDirectory, $"sample_{filter}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the current options
                    image.Save(outputPath, options);

                    // Get the size of the saved file
                    long compressedSize = new FileInfo(outputPath).Length;

                    Console.WriteLine($"Filter: {filter}, compressed size: {compressedSize} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}