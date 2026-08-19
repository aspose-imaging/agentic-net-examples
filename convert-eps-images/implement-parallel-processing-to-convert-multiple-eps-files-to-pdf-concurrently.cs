// HOW-TO: Convert Multiple EPS Files to PDF Concurrently Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
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
            // Hardcoded list of EPS files to convert
            string[] inputPaths = {
                "Samples/input1.eps",
                "Samples/input2.eps",
                "Samples/input3.eps"
            };

            // Process each file in parallel
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputDirectory = "Output";
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Set PDF options (optional compliance setting)
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch of vector EPS graphics needs to be delivered as PDF documents for printing or archiving, a developer can use this code to convert them in parallel, speeding up the workflow.
 * 2. When an automated server process must generate PDF reports from EPS logos or diagrams while handling many files simultaneously, this example shows how to achieve high throughput with Aspose.Imaging.
 * 3. When a desktop application needs to provide users with a fast “Export all EPS to PDF” feature without freezing the UI, the parallel conversion pattern can be applied.
 * 4. When a cloud‑based microservice processes uploaded EPS files and must store them as PDF/A‑1b compliant PDFs for compliance, this code demonstrates the required steps.
 * 5. When a migration script moves legacy EPS assets to a PDF library and wants to utilize multiple CPU cores to reduce conversion time, the parallel loop offers an efficient solution.
 */
