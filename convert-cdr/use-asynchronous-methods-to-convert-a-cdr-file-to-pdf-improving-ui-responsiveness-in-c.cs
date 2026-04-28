using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            await Task.Run(() =>
            {
                using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();

                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };

                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    cdr.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}