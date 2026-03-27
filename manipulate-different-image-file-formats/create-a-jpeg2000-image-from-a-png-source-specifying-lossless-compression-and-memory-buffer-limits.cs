using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG2000 options for lossless compression and buffer size hint
            Jpeg2000Options options = new Jpeg2000Options
            {
                // Irreversible = false (default) => lossless DWT 5-3 compression
                Irreversible = false,
                // Set a memory buffer limit (e.g., 1 MB)
                BufferSizeHint = 1 * 1024 * 1024
            };

            // Save the image as JPEG2000 using the configured options
            image.Save(outputPath, options);
        }
    }
}