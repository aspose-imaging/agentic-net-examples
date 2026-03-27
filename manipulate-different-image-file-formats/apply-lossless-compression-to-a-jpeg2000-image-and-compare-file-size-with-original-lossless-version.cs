using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jp2";
        string outputPath = @"C:\temp\output_lossless.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the original JPEG2000 image
        using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
        {
            // Prepare lossless JPEG2000 options (default Irreversible = false)
            Jpeg2000Options saveOptions = new Jpeg2000Options();

            // Save the image with lossless compression
            jpeg2000Image.Save(outputPath, saveOptions);
        }

        // Compare file sizes
        long originalSize = new FileInfo(inputPath).Length;
        long compressedSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Original size:   {originalSize} bytes");
        Console.WriteLine($"Compressed size: {compressedSize} bytes");
        Console.WriteLine($"Size difference: {originalSize - compressedSize} bytes");
    }
}