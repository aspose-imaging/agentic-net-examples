using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.apng";
        string outputPath = "Output\\output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                using (GifImage gif = new GifImage(new GifFrameBlock((ushort)apng.Width, (ushort)apng.Height)))
                {
                    for (int i = 0; i < apng.PageCount; i++)
                    {
                        using (RasterImage frame = (RasterImage)apng.Pages[i])
                        {
                            gif.AddPage(frame);
                        }
                    }

                    gif.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}