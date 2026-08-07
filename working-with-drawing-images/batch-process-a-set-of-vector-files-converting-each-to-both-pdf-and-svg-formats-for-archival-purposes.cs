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
            // Define base, input and output directories (relative paths)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists (creates if missing)
            Directory.CreateDirectory(inputDirectory);
            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file paths
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                string svgOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure output directories exist before saving
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                // Load the vector image
                using (Image image = Image.Load(inputPath))
                {
                    // Convert to PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        image.Save(pdfOutputPath, pdfOptions);
                    }

                    // Convert to SVG
                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        image.Save(svgOutputPath, svgOptions);
                    }
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
 * 1. When a developer needs to archive a collection of vector drawings (e.g., AI, EPS, SVG) by converting each file to PDF for universal viewing and to SVG for future editing.
 * 2. When a document management system must batch‑process incoming vector assets and store them in both PDF and SVG formats to satisfy compliance and accessibility requirements.
 * 3. When an e‑learning platform wants to generate printable PDFs and web‑ready SVGs from a folder of vector illustrations for course materials.
 * 4. When a GIS application requires automated conversion of map vector files into PDF reports and scalable SVG overlays for integration with other mapping tools.
 * 5. When a marketing automation workflow needs to transform a batch of vector logos into PDF for client review and SVG for responsive web use.
 */