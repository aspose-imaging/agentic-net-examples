using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                BorderX = 50,
                BorderY = 50,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, pdfOptions);
        }
    }
}