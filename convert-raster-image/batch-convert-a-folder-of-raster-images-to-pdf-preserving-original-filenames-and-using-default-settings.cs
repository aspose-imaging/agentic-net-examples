using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDir);
        foreach (string filePath in files)
        {
            string inputPath = filePath;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output PDF path preserving the original filename
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save as PDF using default options
            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}