using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int originalWidth = webp.Width;
                int originalHeight = webp.Height;

                GifOptions gifOptions = new GifOptions();
                webp.Save(outputPath, gifOptions);
                
                using (GifImage gif = (GifImage)Image.Load(outputPath))
                {
                    int gifWidth = gif.Width;
                    int gifHeight = gif.Height;

                    if (originalWidth == gifWidth && originalHeight == gifHeight)
                    {
                        Console.WriteLine($"Dimensions match: {originalWidth}x{originalHeight}");
                    }
                    else
                    {
                        Console.WriteLine($"Dimension mismatch: WebP {originalWidth}x{originalHeight} vs GIF {gifWidth}x{gifHeight}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}