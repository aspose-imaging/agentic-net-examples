using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "result.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage image = (EpsImage)Image.Load(inputPath))
        {
            int newWidth = 2000;
            int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}