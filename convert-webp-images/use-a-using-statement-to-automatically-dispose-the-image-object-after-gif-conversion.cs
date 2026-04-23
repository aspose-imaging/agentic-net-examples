using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string? outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the source image and automatically dispose it after use
        using (Image image = Image.Load(inputPath))
        {
            // Prepare GIF save options (default options are sufficient for basic conversion)
            GifOptions gifOptions = new GifOptions();

            // Save the image as GIF
            image.Save(outputPath, gifOptions);
        }
    }
}