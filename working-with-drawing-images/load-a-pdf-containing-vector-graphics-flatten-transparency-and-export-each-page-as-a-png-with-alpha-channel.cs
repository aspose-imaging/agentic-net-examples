using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pdf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = "output";

        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            int pageCount = multipage?.PageCount ?? 1;

            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                PngOptions options = new PngOptions();

                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    options.VectorRasterizationOptions = vectorOptions;
                }

                options.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                image.Save(outputPath, options);
            }
        }
    }
}