using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.pdf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (Image pdfImage = Image.Load(inputPath))
        {
            int pageCount = 1;
            if (pdfImage is IMultipageImage multipage)
            {
                pageCount = multipage.PageCount;
            }

            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine("Output", $"page_{i + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = pdfImage.Width,
                        PageHeight = pdfImage.Height
                    },
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                })
                {
                    pdfImage.Save(outputPath, pngOptions);
                }
            }
        }
    }
}