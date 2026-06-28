using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image as a vector image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options to preserve vector data and set compliance
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS as a PDF while keeping vector paths editable
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic designer needs to batch‑convert EPS artwork to PDF/A‑1b compliant documents while keeping the original vector paths editable for downstream CAD or illustration tools.
 * 2. When a .NET application must generate searchable, high‑resolution PDFs from EPS logos without rasterizing them, ensuring the vectors remain scalable and editable.
 * 3. When an automated publishing workflow requires preserving vector data during EPS‑to‑PDF conversion so that the resulting PDFs can be further annotated or modified in Adobe Illustrator.
 * 4. When a legal compliance system needs to archive EPS technical drawings as PDF/A‑1b files while retaining editability for future regulatory reviews.
 * 5. When a cloud‑based image processing service uses Aspose.Imaging for C# to convert client‑uploaded EPS files to PDFs without losing vector fidelity, enabling seamless integration with PDF viewers and editors.
 */