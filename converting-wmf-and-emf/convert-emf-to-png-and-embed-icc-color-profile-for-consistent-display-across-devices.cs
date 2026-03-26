using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                }
            };

            emfImage.Save(outputPath, pngOptions);
        }
    }
}