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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the APNG image
        using (Image apngImage = Image.Load(inputPath))
        {
            // Save as GIF using default GifOptions
            var gifOptions = new GifOptions();
            apngImage.Save(outputPath, gifOptions);
        }

        // Verify the saved GIF can be loaded and has frames
        using (Image gifImage = Image.Load(outputPath))
        {
            if (gifImage is GifImage gif && gif.PageCount > 0)
            {
                Console.WriteLine($"GIF saved successfully with {gif.PageCount} frame(s).");
            }
            else
            {
                Console.WriteLine("Failed to verify the saved GIF.");
            }
        }
    }
}