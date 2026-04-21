using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

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

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Process only CDR files
                if (!inputPath.EndsWith(".cdr", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image and export to PDF with high‑quality settings
                using (CdrImage image = (CdrImage)Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}