using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options for infinite looping (0 = infinite)
            var gifOptions = new GifOptions
            {
                LoopsCount = 0
            };

            // Save as GIF with the specified options
            image.Save(outputPath, gifOptions);
        }
    }
}