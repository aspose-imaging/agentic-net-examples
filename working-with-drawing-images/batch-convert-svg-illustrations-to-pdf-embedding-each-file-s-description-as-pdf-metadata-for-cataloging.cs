using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
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

        // Get all SVG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output PDF path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory for the file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options and set metadata (using file name as title)
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = Path.GetFileNameWithoutExtension(inputPath)
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }

            Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
        }
    }
}