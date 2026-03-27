using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            using (var pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = vectorOptions;
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}