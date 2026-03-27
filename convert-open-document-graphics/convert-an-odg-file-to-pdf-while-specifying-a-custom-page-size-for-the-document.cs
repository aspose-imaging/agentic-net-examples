using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\input.odg";
        string outputPath = @"C:\output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions();
            rasterOptions.BackgroundColor = Color.White;
            rasterOptions.PageWidth = 800f;
            rasterOptions.PageHeight = 600f;

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}