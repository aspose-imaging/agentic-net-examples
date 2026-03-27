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
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\frame0.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure WebP options for lossless compression
            var webpOptions = new WebPOptions
            {
                Lossless = true,
                // Export only the first frame (index 0)
                MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, 1))
            };

            // Save the selected frame as a WebP image
            image.Save(outputPath, webpOptions);
        }
    }
}