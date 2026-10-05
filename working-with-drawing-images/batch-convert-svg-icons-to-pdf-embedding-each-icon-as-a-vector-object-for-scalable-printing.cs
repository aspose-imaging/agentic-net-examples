// HOW-TO: Batch Convert SVG Icons to PDF with Vector Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace SvgToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\SvgIcons";
                string outputDirectory = @"C:\PdfIcons";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all SVG files in the input directory
                string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in svgFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output PDF path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load SVG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as PDF preserving vector data
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
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
 * 1. When you need to generate printable PDF catalogs from a folder of SVG icons while keeping them scalable for high‑resolution output.
 * 2. When an automated build process must transform design assets into PDF for inclusion in marketing materials without rasterizing the graphics.
 * 3. When a web application exports user‑uploaded SVG logos as PDF files for legal documents that require vector fidelity.
 * 4. When a CI/CD pipeline creates PDF documentation from SVG diagrams to ensure crisp rendering on any device.
 * 5. When a desktop utility prepares a batch of SVG UI assets for laser‑cutting or embossing by converting them to vector‑based PDFs.
 */
