using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "Output/output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (gif.PageCount < 5)
                {
                    Console.Error.WriteLine("The GIF does not contain a fifth frame.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

                WebPOptions options = new WebPOptions
                {
                    Lossless = true
                };

                gif.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}