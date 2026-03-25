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
        string inputPath = "input.cmx";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.pdf";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        using (PdfOptions pdfOptions = new PdfOptions
        {
            VectorRasterizationOptions = new CmxRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
            }
        })
        {
            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}