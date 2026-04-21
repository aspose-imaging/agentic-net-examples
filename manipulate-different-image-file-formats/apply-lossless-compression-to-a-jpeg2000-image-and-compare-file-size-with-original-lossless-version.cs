using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.jp2";
        string outputPath = "Output\\compressed.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the original JPEG2000 image
        using (Jpeg2000Image original = new Jpeg2000Image(inputPath))
        {
            // Get original file size
            long originalSize = new FileInfo(inputPath).Length;

            // Save with lossless compression (default)
            using (Jpeg2000Options options = new Jpeg2000Options())
            {
                // Explicitly set lossless mode (Irreversible = false)
                options.Irreversible = false;
                original.Save(outputPath, options);
            }

            // Get compressed file size
            long compressedSize = new FileInfo(outputPath).Length;

            // Output size comparison
            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            double ratio = (double)compressedSize / originalSize * 100;
            Console.WriteLine($"Compression ratio: {ratio:F2}%");
        }
    }
}