using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded image does not support multiple pages.");
                return;
            }

            for (int pageIndex = 0; pageIndex < multipage.PageCount; pageIndex++)
            {
                var pngOptions = new PngOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1)),
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    }
                };

                string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                image.Save(outputPath, pngOptions);
            }
        }
    }
}