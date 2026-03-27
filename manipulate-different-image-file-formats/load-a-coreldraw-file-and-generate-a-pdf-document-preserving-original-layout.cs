using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\sample.cdr.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CorelDRAW (CDR) file
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Set up rasterization options specific to CDR
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None,
                Positioning = PositioningTypes.DefinedByDocument
            };

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as a PDF preserving the original layout
            image.Save(outputPath, pdfOptions);
        }
    }
}