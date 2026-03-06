using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input.cdr> <output.pdf>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (Image image = Image.Load(inputPath))
        {
            var pdfOptions = new PdfOptions();

            var rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            image.Save(outputPath, pdfOptions);
        }
    }
}