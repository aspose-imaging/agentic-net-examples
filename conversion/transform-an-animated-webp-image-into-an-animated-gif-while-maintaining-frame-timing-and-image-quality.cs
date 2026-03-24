using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image and save as animated GIF
        using (Image image = Image.Load(inputPath))
        {
            GifOptions gifOptions = new GifOptions();
            // Preserve full frames if needed (optional)
            // gifOptions.FullFrame = true;

            image.Save(outputPath, gifOptions);
        }
    }
}