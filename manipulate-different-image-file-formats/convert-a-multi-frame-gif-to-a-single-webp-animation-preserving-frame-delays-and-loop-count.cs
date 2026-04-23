using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/animation.gif";
        string outputPath = "Output/animation.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image gifImage = Image.Load(inputPath))
            {
                // Prepare WebP options; animation loop count can be set if needed.
                WebPOptions webpOptions = new WebPOptions
                {
                    // Default loop count (0 = infinite) – adjust if source GIF loop count is known.
                    AnimLoopCount = 0
                };

                // Save GIF as animated WebP, preserving frames and delays.
                gifImage.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}