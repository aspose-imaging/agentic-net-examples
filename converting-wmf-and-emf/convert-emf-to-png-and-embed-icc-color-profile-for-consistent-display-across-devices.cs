using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            image.Save(outputPath, pngOptions);
        }
    }
}