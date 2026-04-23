using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();

                // Set custom A4 page size (595 x 842 points)
                pdfOptions.PageSize = new Aspose.Imaging.SizeF(595f, 842f);

                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    PageSize = new Aspose.Imaging.SizeF(595f, 842f)
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}