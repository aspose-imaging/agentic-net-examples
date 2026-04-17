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
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG animation
        using (Image apngImage = Image.Load(inputPath))
        {
            // Save as GIF animation
            apngImage.Save(outputPath, new GifOptions());
        }

        // Simple verification: load the saved GIF and check it has multiple frames
        using (Image gifImage = Image.Load(outputPath))
        {
            // PageCount indicates number of frames in a multipage image
            if (gifImage.PageCount > 1)
            {
                Console.WriteLine("GIF conversion successful: animation contains multiple frames.");
            }
            else
            {
                Console.WriteLine("Warning: GIF conversion may have lost animation frames.");
            }
        }
    }
}