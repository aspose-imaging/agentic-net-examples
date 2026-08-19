// HOW-TO: Convert EPS to PDF While Preserving Vector Data in C# (Aspose.Imaging for .NET)
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
                // Configure PDF options to preserve vector data
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Set PDF compliance (e.g., PDF/A-1b) as required
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the EPS image to PDF using the configured options
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate PDF/A‑1b compliant documents from EPS artwork without rasterizing the graphics, preserving scalability for print‑ready files.
 * 2. When an automated workflow must batch‑convert EPS logos to PDF for inclusion in reports while keeping the vector paths editable.
 * 3. When a web service receives EPS files from designers and must return high‑quality PDFs that retain crisp vector edges for downstream editing.
 * 4. When integrating Aspose.Imaging into a C# application to ensure that converted PDFs maintain the original EPS resolution‑independent quality for archival purposes.
 * 5. When building a document management system that stores PDFs derived from EPS files and requires the PDFs to remain searchable and scalable on any device.
 */
