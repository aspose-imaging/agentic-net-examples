// HOW-TO: Batch Convert Vector Files To PDF And SVG With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace VectorBatchProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\VectorInput";
                string pdfOutputDirectory = @"C:\VectorOutput\PDF";
                string svgOutputDirectory = @"C:\VectorOutput\SVG";

                // Ensure output base directories exist
                Directory.CreateDirectory(pdfOutputDirectory);
                Directory.CreateDirectory(svgOutputDirectory);

                // Get all files in the input directory
                string[] inputFiles = Directory.GetFiles(inputDirectory);

                foreach (string inputPath in inputFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the vector image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare PDF output path
                        string pdfFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                        string pdfOutputPath = Path.Combine(pdfOutputDirectory, pdfFileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
                        image.Save(pdfOutputPath, new PdfOptions());

                        // Prepare SVG output path
                        string svgFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                        string svgOutputPath = Path.Combine(svgOutputDirectory, svgFileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));
                        image.Save(svgOutputPath, new SvgOptions());
                    }
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
 * 1. When a developer needs to archive a collection of design assets by saving each vector drawing as both PDF for document sharing and SVG for web scalability.
 * 2. When an application must automatically generate printable PDFs and responsive SVGs from a folder of AI, EPS, or SVG source files without manual intervention.
 * 3. When a migration script has to convert legacy vector formats into modern, searchable PDF archives while preserving the original SVG for future editing.
 * 4. When a batch processing service needs to read any vector image, create a PDF version for client delivery, and an SVG version for integration into HTML pages.
 * 5. When a developer wants to ensure that every vector file in a directory is saved in two archival formats to meet compliance or backup requirements.
 */
