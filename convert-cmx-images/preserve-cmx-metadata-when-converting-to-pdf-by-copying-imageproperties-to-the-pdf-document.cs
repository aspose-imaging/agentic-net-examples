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
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            PdfOptions pdfOptions = new PdfOptions
            {
                KeepMetadata = true,
                ExifData = cmxImage.ExifData,
                XmpData = cmxImage.XmpData,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                }
            };

            cmxImage.Save(outputPath, pdfOptions);
        }
    }
}