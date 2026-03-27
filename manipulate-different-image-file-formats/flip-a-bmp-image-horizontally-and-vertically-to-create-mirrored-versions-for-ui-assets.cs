using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputHorizontalPath = "output_horizontal.bmp";
        string outputVerticalPath = "output_vertical.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputHorizontalPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputVerticalPath));

        using (Image imgH = Image.Load(inputPath))
        {
            imgH.RotateFlip(RotateFlipType.RotateNoneFlipX);
            BmpOptions bmpOptionsH = new BmpOptions
            {
                Source = new FileCreateSource(outputHorizontalPath, false)
            };
            imgH.Save(outputHorizontalPath, bmpOptionsH);
        }

        using (Image imgV = Image.Load(inputPath))
        {
            imgV.RotateFlip(RotateFlipType.RotateNoneFlipY);
            BmpOptions bmpOptionsV = new BmpOptions
            {
                Source = new FileCreateSource(outputVerticalPath, false)
            };
            imgV.Save(outputVerticalPath, bmpOptionsV);
        }
    }
}