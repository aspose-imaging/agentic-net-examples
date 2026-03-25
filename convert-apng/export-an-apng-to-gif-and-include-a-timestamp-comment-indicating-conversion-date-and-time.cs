using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = $"output_{DateTime.Now:yyyyMMdd_HHmmss}.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Save as GIF with default options
            GifOptions gifOptions = new GifOptions();
            image.Save(outputPath, gifOptions);
        }

        Console.WriteLine($"Conversion completed. GIF saved to: {outputPath}");
    }
}