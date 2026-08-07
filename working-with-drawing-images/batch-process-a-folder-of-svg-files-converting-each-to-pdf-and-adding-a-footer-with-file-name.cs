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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When a C# application must batch‑process a folder of SVG images, converting each to PDF with Aspose.Imaging and automatically appending a footer that displays the original file name for branding or traceability.
 * 2. When an automated document generation pipeline uses Aspose.Imaging for .NET to turn a collection of SVG diagrams into PDF reports, adding a file‑name footer so reviewers can identify the source of each page.
 * 3. When a SaaS platform receives multiple user‑uploaded SVG assets and needs to generate downloadable PDFs that include a footer with the asset’s filename to comply with audit requirements.
 * 4. When a desktop utility written in C# needs to convert SVG icons to PDF for printing, inserting a footer with the icon’s name to help designers match printed assets to their source files.
 * 5. When a migration script leverages Aspose.Imaging to bulk‑convert legacy SVG files to PDF while embedding a filename footer, ensuring the new PDFs retain a reference to the original assets for future maintenance.
 */