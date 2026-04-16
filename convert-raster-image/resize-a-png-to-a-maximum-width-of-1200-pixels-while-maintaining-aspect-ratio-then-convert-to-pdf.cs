using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            const int maxWidth = 1200;
            if (image.Width > maxWidth)
            {
                double ratio = (double)maxWidth / image.Width;
                int newWidth = maxWidth;
                int newHeight = (int)(image.Height * ratio);
                image.Resize(newWidth, newHeight);
            }

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}