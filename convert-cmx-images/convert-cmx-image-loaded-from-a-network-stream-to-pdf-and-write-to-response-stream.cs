using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.cmx";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                image.Save(outputPath, pdfOptions);
            }
        }
    }
}