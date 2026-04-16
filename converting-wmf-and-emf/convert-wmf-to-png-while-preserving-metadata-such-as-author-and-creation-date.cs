using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image and save as PNG preserving metadata
        using (Image image = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                // Preserve original metadata (author, creation date, etc.)
                KeepMetadata = true
            };

            image.Save(outputPath, pngOptions);
        }
    }
}