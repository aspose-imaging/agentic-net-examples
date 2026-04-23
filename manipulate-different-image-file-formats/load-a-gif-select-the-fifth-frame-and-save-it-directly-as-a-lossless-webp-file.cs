using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.gif";
        string outputPath = "Output\\frame5.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount < 5)
                {
                    Console.Error.WriteLine("GIF does not contain a fifth frame.");
                    return;
                }

                // Select the fifth frame (zero‑based index 4)
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

                // Save the selected frame as a lossless WebP image
                WebPOptions options = new WebPOptions { Lossless = true };
                gif.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}