using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Author = "Automated" };
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}