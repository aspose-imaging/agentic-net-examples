using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/eps.bin";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath, new Aspose.Imaging.FileFormats.Eps.EpsLoadOptions()))
        {
            var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)image;
            var pdfOptions = new PdfOptions();
            epsImage.Save(outputPath, pdfOptions);
        }
    }
}