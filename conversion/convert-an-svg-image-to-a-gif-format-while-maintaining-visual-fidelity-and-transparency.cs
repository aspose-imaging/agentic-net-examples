using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            GifOptions gifOptions = new GifOptions();

            if (image is Aspose.Imaging.VectorImage)
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };
                gifOptions.VectorRasterizationOptions = rasterOptions;
            }

            image.Save(outputPath, gifOptions);
        }
    }
}