using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            EmfImage emfImage = (EmfImage)image;

            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height
                };
                emfImage.Save(outputPath, pngOptions);
            }
        }
    }
}