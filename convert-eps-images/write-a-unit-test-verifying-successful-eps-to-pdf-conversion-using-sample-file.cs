using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                image.Save(outputPath, options);
            }

            if (File.Exists(outputPath))
            {
                Console.WriteLine("EPS to PDF conversion succeeded.");
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: output file not created.");
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
 * 1. When a developer needs to automatically convert vector EPS artwork received from a designer into PDF/A‑1b compliant documents for archival or printing workflows using C# and Aspose.Imaging.
 * 2. When an application must validate that a batch job successfully creates PDF files from EPS source files before moving them to a document management system.
 * 3. When a web service processes user‑uploaded EPS files and returns a PDF version, requiring a unit test to ensure the conversion routine works without throwing exceptions.
 * 4. When a CI/CD pipeline includes a test that checks the Aspose.Imaging EPS‑to‑PDF conversion produces an output file on disk, guaranteeing build stability for image processing features.
 * 5. When a developer wants to confirm that the PdfOptions settings, such as PdfCoreOptions and PdfComplianceVersion.PdfA1b, are correctly applied during the EPS to PDF conversion in a .NET project.
 */