// HOW-TO: Increase Brightness of Animated GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output\\brightened.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;
                gif.AdjustBrightness(50);
                gif.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to make a dark animated GIF clearer for web banners by programmatically boosting its brightness in C#.
 * 2. When you want to preprocess a series of GIF frames before creating an animated GIF to improve visual quality in a slideshow application.
 * 3. When an e‑learning platform requires brighter GIF animations to enhance readability on mobile devices using Aspose.Imaging.
 * 4. When a marketing tool automatically adjusts the brightness of user‑uploaded GIFs to match brand color guidelines before saving them.
 * 5. When a game developer needs to brighten sprite animations stored as GIFs to ensure they stand out against dark backgrounds.
 */
