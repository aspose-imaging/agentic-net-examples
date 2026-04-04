using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input GIF file paths
        string[] inputPaths = {
            @"C:\InputGifs\anim1.gif",
            @"C:\InputGifs\anim2.gif"
        };

        foreach (var inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output path (adds "_compressed" suffix)
            string outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath) ?? string.Empty,
                Path.GetFileNameWithoutExtension(inputPath) + "_compressed.gif");

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load GIF, apply lossy compression, and save
            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions
                {
                    // Enable lossy compression (recommended value: 80)
                    MaxDiff = 80
                };

                image.Save(outputPath, options);
            }
        }
    }
}