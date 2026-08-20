// HOW-TO: Resize EPS to 2000px Width and Save as PDF/A‑1b in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\source.eps";
            string outputPath = @"C:\Images\result.pdf";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new height to preserve aspect ratio for a width of 2000 pixels
                int newWidth = 2000;
                int newHeight = (int)((double)epsImage.Height / epsImage.Width * newWidth);

                // Resize the image using a high‑quality resampling method
                epsImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare PDF export options with PDF/A‑1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the resized image as a PDF file
                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to downscale a large EPS illustration to a fixed 2000‑pixel width while preserving aspect ratio before archiving it as a PDF/A‑1b compliant document.
 * 2. When a printing workflow requires converting vector EPS artwork into a PDF/A‑1b file with a specific pixel width for consistent on‑screen preview.
 * 3. When generating PDF reports that must include resized EPS graphics meeting PDF/A‑1b standards for long‑term preservation.
 * 4. When automating batch processing of EPS logos to fit within a 2000‑pixel width constraint and exporting them as PDF/A‑1b for legal document submission.
 * 5. When a web application needs to transform user‑uploaded EPS files into PDF/A‑1b PDFs of a known size for display in browsers that only support rasterized PDFs.
 */
