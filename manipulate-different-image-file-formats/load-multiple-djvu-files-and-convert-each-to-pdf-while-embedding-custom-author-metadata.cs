using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, and output directories
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

        // Get all DjVu files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output PDF path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            // Ensure output directory exists (unconditional as per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu image and convert to PDF with custom author metadata
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
                    }
                };

                djvuImage.Save(outputPath, pdfOptions);
            }
        }
    }
}