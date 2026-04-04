using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Temp\multipage.svg";
        string outputPath = @"C:\Temp\output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            PdfOptions exportOptions = new PdfOptions();

            if (image is IMultipageImage multipage && multipage.PageCount > 0)
            {
                exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            if (image is VectorImage)
            {
                exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
            }

            image.Save(outputPath, exportOptions);
        }
    }
}