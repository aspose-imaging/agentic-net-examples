using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/animated.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document and export pages 7‑9 as an animated GIF
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Configure GIF options with specific page indexes (zero‑based: 6,7,8)
            GifOptions gifOptions = new GifOptions
            {
                MultiPageOptions = new DjvuMultiPageOptions(new int[] { 6, 7, 8 })
            };

            // Save the animated GIF
            djvuImage.Save(outputPath, gifOptions);
        }
    }
}