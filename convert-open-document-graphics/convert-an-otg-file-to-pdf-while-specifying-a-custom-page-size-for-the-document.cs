using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\sample.otg";
        string outputPath = "C:\\Images\\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image and convert to PDF
        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions();
            rasterOptions.BackgroundColor = Color.White;
            rasterOptions.PageSize = new SizeF(595f, 842f); // A4 size in points

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}