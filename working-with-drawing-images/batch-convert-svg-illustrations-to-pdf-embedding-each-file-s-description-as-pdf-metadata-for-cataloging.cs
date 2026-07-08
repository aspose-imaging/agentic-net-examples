using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all SVG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        try
        {
            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options with metadata
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo
                        {
                            // Use the file name as the title/description
                            Title = fileNameWithoutExt,
                            Subject = $"Converted from {fileNameWithoutExt}.svg"
                        };

                        // Save as PDF
                        image.Save(outputPath, pdfOptions);
                    }
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a design team needs to archive a library of vector icons as searchable PDF catalogs, a developer can use this code to batch convert SVG illustrations to PDF and store each icon’s description in the PDF metadata.
 * 2. When an e‑learning platform wants to generate printable course handouts from SVG diagrams while preserving metadata for indexing, this code enables automated conversion of multiple SVG files into PDF with embedded descriptions.
 * 3. When a marketing department must deliver client‑approved SVG artwork as PDF portfolios that include project notes, a developer can run this routine to convert and embed the notes as PDF metadata for easy retrieval.
 * 4. When a regulatory compliance system requires all SVG schematics to be stored as PDF records with descriptive metadata for audit trails, this code provides a batch conversion solution in C#.
 * 5. When a content management system needs to ingest SVG assets and create searchable PDF versions for SEO and AI indexing, the code can process the files in bulk and embed each file’s description into the PDF metadata.
 */