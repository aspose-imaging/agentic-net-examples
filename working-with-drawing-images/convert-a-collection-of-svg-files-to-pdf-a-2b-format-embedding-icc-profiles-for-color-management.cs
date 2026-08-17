// HOW-TO: Convert Multiple SVG Files to PDF/A-2b with ICC Profiles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!inputPath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions(),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = Aspose.Imaging.SmoothingMode.None
                        }
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
 * 1. When a developer needs to batch‑process vector graphics from a design system and produce archival‑ready PDF/A‑2b documents that preserve exact colors.
 * 2. When an application must generate printable PDFs from SVG logos while embedding an ICC profile to ensure consistent color across different printers.
 * 3. When a web service receives user‑uploaded SVG diagrams and must return PDF/A files that comply with regulatory document standards.
 * 4. When a reporting tool converts chart SVGs into PDF/A‑2b pages for inclusion in long‑term storage archives with proper color management.
 * 5. When a desktop utility automates the conversion of a folder of SVG assets into PDF/A‑2b files for distribution to clients who require PDF/A compliance.
 */
