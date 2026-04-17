using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page CDR document
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Set custom A4 page size (595 x 842 points)
            pdfOptions.PageSize = new SizeF(595f, 842f);

            // Configure rasterization options for CDR vector content
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the entire CDR document as a PDF with A4 pages
            image.Save(outputPath, pdfOptions);
        }
    }
}