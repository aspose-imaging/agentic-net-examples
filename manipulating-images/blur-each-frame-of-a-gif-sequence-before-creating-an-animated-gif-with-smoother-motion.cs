using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
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

            using (Image image = Image.Load(inputPath))
            {
                var gif = (Aspose.Imaging.FileFormats.Gif.GifImage)image;
                int pageCount = gif.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[i];
                    gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                }

                gif.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}