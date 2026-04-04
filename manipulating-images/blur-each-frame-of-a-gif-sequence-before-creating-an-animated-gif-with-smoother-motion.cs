using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        string inputPath = "input.gif";
        string outputPath = "output_blurred.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
        {
            var gif = (Aspose.Imaging.FileFormats.Gif.GifImage)img;

            for (int i = 0; i < gif.PageCount; i++)
            {
                gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[i];
                gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            }

            var options = new GifOptions();
            gif.Save(outputPath, options);
        }
    }
}