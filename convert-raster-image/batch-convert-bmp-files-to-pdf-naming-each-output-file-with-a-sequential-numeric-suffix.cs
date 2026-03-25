using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all BMP files in the input directory
        string[] inputFiles = Directory.GetFiles(inputDirectory, "*.bmp");

        int index = 1;
        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path with sequential numeric suffix
            string outputPath = Path.Combine(outputDirectory, $"output_{index}.pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image and save as PDF
            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }

            index++;
        }
    }
}