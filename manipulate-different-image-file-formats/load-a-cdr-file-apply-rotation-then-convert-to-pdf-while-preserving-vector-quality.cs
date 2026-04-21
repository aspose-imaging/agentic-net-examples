using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CDR image, apply rotation, and save as PDF preserving vector quality
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Rotate the vector image by 90 degrees (adjust as needed)
            cdrImage.Rotate(90f);

            // Prepare PDF options with vector rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };
            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rotated image to PDF
            cdrImage.Save(outputPath, pdfOptions);
        }
    }
}