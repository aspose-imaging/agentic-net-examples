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
            // Set up base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files (filter later for .emf)
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                // Process only EMF files
                if (!string.Equals(Path.GetExtension(inputPath), ".emf", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image and save as PDF with title as bookmark
                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = Path.GetFileNameWithoutExtension(inputPath)
                    };

                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a developer needs to generate a searchable PDF portfolio from a collection of Windows Metafile (EMF) diagrams and wants each diagram listed as a clickable bookmark using C# and Aspose.Imaging.
 * 2. When an automated reporting tool must convert dozens of EMF charts produced by a legacy application into PDF files for distribution, preserving the original filenames as PDF bookmarks for easy navigation.
 * 3. When a document management system requires batch processing of EMF assets into PDF format while maintaining a clear table of contents based on the source file names, leveraging Aspose.Imaging’s Image.Load and PdfOptions in .NET.
 * 4. When a CI/CD pipeline includes a step that validates visual assets by converting EMF icons to PDF and embedding their filenames as bookmarks to simplify review by QA engineers.
 * 5. When a cloud‑based microservice receives EMF files via an API and needs to return PDF documents with each file’s name as a bookmark, using the provided C# code to handle the conversion and naming automatically.
 */