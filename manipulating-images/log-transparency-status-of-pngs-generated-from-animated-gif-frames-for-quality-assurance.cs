using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.gif";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    bool gifHasTransparency = gif.HasTransparentColor;

                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as PNG
                    gif.Save(outputPath, new PngOptions());

                    // Load the saved PNG to verify its alpha channel
                    bool pngHasAlpha = false;
                    using (RasterImage png = (RasterImage)Image.Load(outputPath))
                    {
                        pngHasAlpha = png.HasAlpha;
                    }

                    Console.WriteLine($"Frame {i}: GIF transparency = {gifHasTransparency}, PNG alpha = {pngHasAlpha}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}