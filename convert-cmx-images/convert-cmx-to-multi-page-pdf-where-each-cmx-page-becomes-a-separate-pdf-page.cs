using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            PdfOptions pdfOptions = new PdfOptions();

            if (cmxImage is VectorImage)
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = vectorOptions;
            }

            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}