using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage image = (CdrImage)Image.Load(inputPath))
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load CDR image.");
                return;
            }

            CdrImagePage page = (CdrImagePage)image.Pages[0];

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
    }
}