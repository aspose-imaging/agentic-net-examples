using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CDR file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\doc1.cdr",
            @"C:\Images\doc2.cdr",
            @"C:\Images\doc3.cdr"
        };

        // Hardcoded output PDF path
        string outputPath = @"C:\Images\Combined.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PDF options with CDR rasterization settings
        PdfOptions pdfOptions = new PdfOptions();
        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
        {
            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
            SmoothingMode = Aspose.Imaging.SmoothingMode.None,
            Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
        };
        pdfOptions.VectorRasterizationOptions = rasterOptions;

        // Open output stream once and append each CDR document as PDF pages
        using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
        {
            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load CDR image
                using (Image cdrImage = Image.Load(inputPath))
                {
                    // Save the CDR image (all its pages) to the PDF stream
                    cdrImage.Save(outStream, pdfOptions);
                }
            }
        }
    }
}