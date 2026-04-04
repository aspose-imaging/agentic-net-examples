using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir);

        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            if (gif.PageCount == 0)
            {
                Console.Error.WriteLine("The GIF contains no frames.");
                return;
            }

            // Set the first frame as active
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

            // Apply Magic Wand selection on the active frame
            MagicWandTool
                .Select((RasterImage)gif, new MagicWandSettings(10, 10) { Threshold = 100 })
                .Apply();

            // Save the modified GIF animation
            GifOptions options = new GifOptions();
            gif.Save(outputPath, options);
        }
    }
}