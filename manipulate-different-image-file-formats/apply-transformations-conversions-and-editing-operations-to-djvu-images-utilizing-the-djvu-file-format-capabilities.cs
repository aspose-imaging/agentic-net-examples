using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        string inputPath = "input\\sample.djvu";
        string outputPath = "output\\resized.png";
        string pageOutputPattern = "output\\page_{0}.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            djvuImage.Resize(djvuImage.Width * 2, djvuImage.Height * 2, ResizeType.NearestNeighbourResample);

            using (var pngOptions = new PngOptions())
            {
                djvuImage.Save(outputPath, pngOptions);
            }

            for (int i = 0; i < djvuImage.PageCount; i++)
            {
                using (RasterImage page = (RasterImage)djvuImage.Pages[i])
                {
                    if (!page.IsCached) page.CacheData();
                    page.Grayscale();

                    string pagePath = string.Format(pageOutputPattern, i + 1);
                    Directory.CreateDirectory(Path.GetDirectoryName(pagePath));

                    using (var pngOptions = new PngOptions())
                    {
                        page.Save(pagePath, pngOptions);
                    }
                }
            }
        }
    }
}