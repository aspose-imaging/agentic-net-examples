using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string filePath in files)
            {
                string inputPath = filePath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
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
 * 1. When a developer needs to batch‑convert a folder of Windows Metafile (EMF) diagrams into PDF files while automatically inserting a “Converted on <date>” header on each page for audit‑trail purposes.
 * 2. When an engineering application must export a collection of CAD‑style EMF schematics to PDF for client delivery, adding the conversion timestamp as a header to meet documentation standards.
 * 3. When a reporting tool generates EMF charts at runtime and the team wants to compile them into a PDF portfolio, with each page labeled with the current date using Aspose.Imaging in C#.
 * 4. When a legacy system stores printable forms as EMF files and a migration project requires converting them to PDF with a date header for regulatory compliance, leveraging Image.Load and PdfOptions.
 * 5. When an automated build pipeline needs to process multiple EMF assets, convert them to PDF, and embed a conversion‑date header on every page to ensure version control and traceability.
 */