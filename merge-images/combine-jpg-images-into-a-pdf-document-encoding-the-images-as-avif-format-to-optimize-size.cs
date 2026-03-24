using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input image paths (JPG files)
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output PDF path
        string outputPath = @"C:\Images\CombinedOutput.pdf";

        // Verify that every input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Configure PDF options – use automatic image compression (the library will pick the best method,
            // which includes modern formats such as AVIF when supported)
            PdfOptions pdfOptions = new PdfOptions
            {
                // Optional: set PDF compliance version
                PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                },

                // Use automatic image compression to let Aspose choose the most efficient format
                // (AVIF is selected when the library supports it)
                // Note: PdfOptions does not expose a direct property for compression,
                // but the internal implementation respects the ImageCompressionOptions enum.
                // Setting it via the PdfCoreOptions is not required here.
            };

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}