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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\sample.cdr";
            string outputPath = @"C:\Temp\sample_rotated.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare PDF save options with rasterization settings
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rotated image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic designer needs to automatically rotate a CorelDRAW (CDR) illustration 90° clockwise and generate a PDF for client review.
 * 2. When a batch‑processing service must convert legacy CDR files to PDF while ensuring the orientation matches printed specifications.
 * 3. When an e‑learning platform imports user‑uploaded CorelDRAW diagrams, rotates them for landscape layout, and saves them as PDF assets.
 * 4. When a document management system standardizes incoming CDR artwork by rotating it and rasterizing it into PDF for archival compliance.
 * 5. When a C# application integrates Aspose.Imaging to adjust the orientation of vector graphics before embedding the PDF into a report or presentation.
 */