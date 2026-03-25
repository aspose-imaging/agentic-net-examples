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

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all BMP files in the input directory
        string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp");

        foreach (string inputPath in bmpFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create a unique timestamp prefix
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            // Build the output PDF file name with timestamp prefix
            string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(inputPath)}.pdf";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}