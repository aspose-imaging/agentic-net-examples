using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with A4 page size
                PdfOptions pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(595f, 842f) // A4 size in points (1 point = 1/72 inch)
                };

                // Set vector rasterization options for CDR
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageSize = new SizeF(595f, 842f) // Ensure each page uses A4 size
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the document as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}