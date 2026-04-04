using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of input CDR files
        string[] inputFiles = new[]
        {
            @"C:\Data\file1.cdr",
            @"C:\Data\file2.cdr",
            @"C:\Data\file3.cdr"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Data\Output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output PDF path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Set rasterization options to render text as vector shapes
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Export the CDR (all pages) to a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}