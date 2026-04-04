using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.gif";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            gif.RotateFlip(RotateFlipType.RotateNoneFlipX);
            gif.Rotate(15f, true, Color.White);
            gif.Save(outputPath, new GifOptions());
            Console.WriteLine($"Transformed GIF saved to {outputPath}");
        }
    }
}