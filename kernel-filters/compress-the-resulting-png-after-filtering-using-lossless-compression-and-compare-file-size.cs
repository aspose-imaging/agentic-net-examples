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
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\compressed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
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

            long bestSize = long.MaxValue;
            PngFilterType bestFilter = PngFilterType.None;

            // Evaluate each filter type using a memory stream
            foreach (PngFilterType filter in filterTypes)
            {
                var options = new PngOptions
                {
                    CompressionLevel = 9,          // Max compression (lossless)
                    FilterType = filter,
                    Progressive = true
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, options);
                    long size = ms.Length;
                    Console.WriteLine($"Filter: {filter}, Size: {size} bytes");

                    if (size < bestSize)
                    {
                        bestSize = size;
                        bestFilter = filter;
                    }
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the image with the best filter found
            var finalOptions = new PngOptions
            {
                CompressionLevel = 9,
                FilterType = bestFilter,
                Progressive = true
            };

            image.Save(outputPath, finalOptions);
            Console.WriteLine($"Saved compressed PNG using filter {bestFilter} to {outputPath} (size: {bestSize} bytes)");
        }
    }
}