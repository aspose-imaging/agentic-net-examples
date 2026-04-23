using System;
using System.IO;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                cdr.CacheData();

                int cropWidth = 500;
                int cropHeight = 500;
                int x = (cdr.Width - cropWidth) / 2;
                int y = (cdr.Height - cropHeight) / 2;
                var rect = new Aspose.Imaging.Rectangle(x, y, cropWidth, cropHeight);
                cdr.Crop(rect);

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = new CdrRasterizationOptions();

                cdr.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}