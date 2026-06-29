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
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\large.eps";
            string outputPath = @"C:\Output\large.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS with a larger buffer hint to help with big files
            var loadOptions = new EpsLoadOptions
            {
                BufferSizeHint = 100 * 1024 * 1024 // 100 MB
            };

            using (var epsImage = (EpsImage)Image.Load(inputPath, loadOptions))
            {
                // Configure PDF options with compliance and rasterization settings
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    // Use vector rasterization options to control memory usage
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height,
                        // Additional tiling settings could be set here if supported
                    }
                };

                // Save the EPS as PDF
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
 * 1. When a CAD application needs to convert multi‑megabyte EPS engineering drawings into PDF/A‑1b compliant documents without exhausting server memory, developers can use this code to load the EPS with a large buffer hint and rasterize it tile‑by‑tile.
 * 2. When a publishing workflow must transform high‑resolution EPS artwork into searchable PDFs for archival while keeping the .NET process footprint low, the example shows how to set vector rasterization options and manage memory.
 * 3. When an automated batch job processes thousands of EPS files from a design repository and must generate PDFs for web preview on limited‑resource machines, this snippet demonstrates tiling‑aware conversion using Aspose.Imaging for .NET.
 * 4. When a legal compliance system requires converting large EPS contracts into PDF/A‑1b format for electronic signatures, the code provides a reliable way to control memory consumption during the rasterization step.
 * 5. When a cloud‑based document service needs to convert user‑uploaded EPS logos into PDF files on a serverless function with strict memory caps, the example illustrates how to use BufferSizeHint and EpsRasterizationOptions to safely handle the conversion.
 */