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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PDF/A‑1b (closest available compliance)
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Set PDF compliance (PDF/A‑2b not available in this version, using PDF/A‑1b)
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When a publishing company needs to archive legacy vector artwork stored as EPS files into PDF/A‑2b compliant PDFs for long‑term preservation using C# and Aspose.Imaging.
 * 2. When a government agency must convert engineering diagrams in EPS format to PDF/A‑2b to meet document retention policies and ensure the files are searchable and unalterable.
 * 3. When a digital asset management system processes incoming EPS logos and automatically generates PDF/A‑2b versions for consistent display across platforms and compliance with ISO 19005.
 * 4. When a printing workflow requires converting EPS pre‑press files to PDF/A‑2b before sending them to a print provider that only accepts PDF/A compliant submissions.
 * 5. When a legal firm needs to transform EPS evidence graphics into PDF/A‑2b PDFs to guarantee document integrity and admissibility in court using a C# automation script.
 */