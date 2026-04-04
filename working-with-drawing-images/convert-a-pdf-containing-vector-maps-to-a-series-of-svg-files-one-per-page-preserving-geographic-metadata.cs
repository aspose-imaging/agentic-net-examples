using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string inputPath = "input.pdf";
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
                Console.Error.WriteLine("The input PDF does not support multiple pages.");
                return;
            }

            int pageCount = multipage.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                SvgOptions exportOptions = new SvgOptions();
                exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions();
                    vectorOptions.BackgroundColor = Color.White;
                    vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                    vectorOptions.SmoothingMode = SmoothingMode.None;
                    exportOptions.VectorRasterizationOptions = vectorOptions;
                }

                image.Save(outputPath, exportOptions);
            }
        }
    }
}