// HOW-TO: Convert Multiple CMX Files to PDF in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmXToPdfBatchIntegrationTest
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\IntegrationTest\CMX";
                string outputDirectory = @"C:\IntegrationTest\PDF";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all CMX files in the input directory
                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cmx", SearchOption.AllDirectories);

                // Process each file in parallel
                Parallel.ForEach(inputFiles, inputPath =>
                {
                    // Validate input file existence
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load CMX image and save as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a large collection of CorelDRAW CMX drawings into searchable PDF documents for archiving.
 * 2. When a build pipeline must verify that all CMX assets are correctly rendered as PDFs before deployment.
 * 3. When a desktop application processes user‑uploaded CMX files and generates PDF reports without blocking the UI.
 * 4. When a server‑side service performs bulk conversion of CMX designs to PDF for printing or e‑signature workflows.
 * 5. When integration tests must ensure that parallel conversion of CMX to PDF produces accurate results and handles missing files gracefully.
 */
