// HOW-TO: Crop Central 500x500 Area From CDR And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Determine central 500x500 rectangle
                int cropWidth = 500;
                int cropHeight = 500;
                int left = Math.Max((cdr.Width - cropWidth) / 2, 0);
                int top = Math.Max((cdr.Height - cropHeight) / 2, 0);
                Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                cdr.Crop(cropRect);

                // Prepare PDF options with default rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the cropped image as PDF
                cdr.Save(outputPath, pdfOptions);
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
 * 1. When you need to extract a specific central region of a CorelDRAW file and deliver it as a PDF report.
 * 2. When automating batch processing to generate PDFs that only contain the most important part of each CDR artwork.
 * 3. When integrating Aspose.Imaging into a web service that receives CDR uploads and returns a cropped PDF preview.
 * 4. When creating thumbnails or printable sections from large CDR designs without manually opening the file in CorelDRAW.
 * 5. When converting legacy CDR assets to PDF while ensuring the output matches a fixed 500‑pixel square area for consistency.
 */
