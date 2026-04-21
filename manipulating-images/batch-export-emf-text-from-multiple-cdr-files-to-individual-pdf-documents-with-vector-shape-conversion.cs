using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of input CDR files
            string[] inputFiles = new[]
            {
                @"C:\Images\Sample1.cdr",
                @"C:\Images\Sample2.cdr",
                @"C:\Images\Sample3.cdr"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path (same folder, same name, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare PDF options with CDR rasterization settings
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            // Render text as vector shapes (single‑bit per pixel rendering)
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                            // Preserve original page size
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    // Export the whole CDR document to a single PDF file
                    cdrImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}