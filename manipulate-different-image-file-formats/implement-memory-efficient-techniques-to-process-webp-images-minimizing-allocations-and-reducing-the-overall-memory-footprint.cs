using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates even if already exists)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Use a stream to avoid loading the whole file into memory at once
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // LoadOptions with a modest buffer size to limit allocations
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 1024 * 1024 // 1 MB buffer
            };

            // Load the WebP image from the stream with the specified load options
            using (WebPImage webPImage = new WebPImage(inputStream, loadOptions))
            {
                // Save directly to PNG using minimal additional allocations
                var pngOptions = new PngOptions();
                webPImage.Save(outputPath, pngOptions);
            }
        }
    }
}