using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string pdfOutputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

                using (Image image = Image.Load(inputPath))
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(pdfOutputPath, pdfOptions);
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
 * 1. When a developer needs to archive a collection of vector drawings (e.g., AI, EPS, SVG) as searchable PDF documents for long‑term storage, they can use this batch conversion code with Aspose.Imaging.
 * 2. When an automated nightly job must transform all newly uploaded design files in a folder into PDF format for compliance reporting, the loop that loads each image and saves it with PdfOptions is ideal.
 * 3. When a web service receives a zip of vector assets and must return PDF versions for client preview, the code demonstrates how to iterate through the files, load them with Image.Load, and generate PDFs in an output directory.
 * 4. When a company wants to migrate legacy CAD or illustration files to a universal, platform‑independent format without manual effort, this C# script shows how to programmatically convert each file to PDF in bulk.
 * 5. When a CI/CD pipeline includes a step to verify that all vector assets can be rendered correctly, the sample illustrates how to load each file, catch loading errors, and produce PDF outputs for visual inspection.
 */