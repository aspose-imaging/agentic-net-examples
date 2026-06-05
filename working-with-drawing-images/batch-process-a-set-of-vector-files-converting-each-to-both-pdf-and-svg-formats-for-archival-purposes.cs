using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists (no validation required per task, but create if missing)
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all vector files (common extensions)
            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".svg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".cdr", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".cmx", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".emf", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output paths
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                string svgOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure output directories exist
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    // Save as PDF
                    var pdfOptions = new PdfOptions();
                    image.Save(pdfOutputPath, pdfOptions);

                    // Save as SVG
                    var svgRasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = svgRasterOptions
                    };
                    image.Save(svgOutputPath, svgOptions);
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
 * 1. When a company needs to archive legacy vector graphics from design tools by converting them into searchable PDF and web‑ready SVG files using C# and Aspose.Imaging.
 * 2. When a document management system must ingest a mixed collection of .cdr, .wmf, .emf, and .svg files and store standardized PDF and SVG versions for long‑term preservation.
 * 3. When an automated build pipeline has to generate PDF reports and SVG thumbnails from a batch of vector assets to ensure consistent rendering across browsers and printers.
 * 4. When a legal compliance team requires batch conversion of vector drawings into PDF/A and SVG formats to meet regulatory record‑keeping standards with minimal manual effort.
 * 5. When a cloud‑based archival service processes user‑uploaded vector files in bulk, converting each to PDF for offline viewing and to SVG for scalable web display using Aspose.Imaging for .NET.
 */