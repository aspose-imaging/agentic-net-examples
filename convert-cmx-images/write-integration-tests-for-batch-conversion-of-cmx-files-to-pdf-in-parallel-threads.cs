// HOW-TO: Parallel Batch Convert CMX Files to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories (relative to current directory)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all CMX files in the input directory
            string[] cmxFiles = Directory.GetFiles(inputDir, "*.cmx");

            // Process each file in parallel
            System.Threading.Tasks.Parallel.ForEach(cmxFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CMX image and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a large collection of CorelDRAW CMX drawings to PDF quickly by leveraging multiple CPU cores in a C# application.
 * 2. When an automated build or CI pipeline must generate PDF reports from CMX assets stored in an input folder without manual intervention.
 * 3. When a desktop utility has to process user‑uploaded CMX files in parallel and save the resulting PDFs to a designated output directory.
 * 4. When you want to ensure each CMX file exists before conversion and handle missing files gracefully during batch processing.
 * 5. When you require thread‑safe creation of output folders and logging of conversion results while using Aspose.Imaging for .NET.
 */
