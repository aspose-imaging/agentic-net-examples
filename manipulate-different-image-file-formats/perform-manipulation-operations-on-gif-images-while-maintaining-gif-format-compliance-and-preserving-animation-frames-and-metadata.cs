using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            for (int i = 0; i < gif.PageCount; i++)
            {
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                gif.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            GifOptions options = new GifOptions
            {
                LoopsCount = gif.LoopsCount,
                KeepMetadata = true
            };

            gif.Save(outputPath, options);
        }
    }
}