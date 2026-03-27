using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Check that the GIF has at least five frames
            if (gif.PageCount < 5)
            {
                Console.Error.WriteLine("The GIF does not contain a fifth frame.");
                return;
            }

            // Select the fifth frame (zero‑based index)
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

            // Save the selected frame as a lossless WebP file
            gif.Save(outputPath, new WebPOptions { Lossless = true });
        }
    }
}