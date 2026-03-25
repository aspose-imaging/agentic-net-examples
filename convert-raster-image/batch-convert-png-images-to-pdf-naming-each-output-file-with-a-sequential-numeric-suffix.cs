using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Get all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

        int counter = 1;
        foreach (string inputPath in pngFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path with sequential numeric suffix
            string outputFileName = $"output{counter}.pdf";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG image and save as PDF
            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }

            counter++;
        }
    }
}