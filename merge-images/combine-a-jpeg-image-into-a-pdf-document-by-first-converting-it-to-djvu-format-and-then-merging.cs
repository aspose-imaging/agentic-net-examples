using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg";
        string djvuPath = "temp.djvu";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(djvuPath));

        File.Copy(inputPath, djvuPath, true);

        using (Stream djvuStream = File.OpenRead(djvuPath))
        {
            using (DjvuImage djvuImage = new DjvuImage(djvuStream))
            {
                PdfOptions pdfOptions = new PdfOptions();
                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}