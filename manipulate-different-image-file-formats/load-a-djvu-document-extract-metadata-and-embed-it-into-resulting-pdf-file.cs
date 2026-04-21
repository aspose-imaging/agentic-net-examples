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
        string inputPath = Path.Combine("Input", "sample.djvu");
        string outputPath = Path.Combine("Output", "result.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvu = (DjvuImage)image;

            int identifier = djvu.Identifier;
            var xmpData = djvu.XmpData;

            PdfOptions pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = identifier.ToString()
                },
                XmpData = xmpData
            };

            image.Save(outputPath, pdfOptions);
        }
    }
}