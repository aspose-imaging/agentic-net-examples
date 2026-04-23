using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputFolder);

        // List of BMP files to process (hardcoded for the example)
        string[] bmpFiles = new string[]
        {
            "image1.bmp",
            "image2.bmp",
            "image3.bmp"
        };

        foreach (string fileName in bmpFiles)
        {
            // Build full input path
            string inputPath = Path.Combine(inputFolder, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create a unique timestamp prefix
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Build full output path with timestamp prefix and .pdf extension
            string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(fileName)}.pdf";
            string outputPath = Path.Combine(outputFolder, outputFileName);

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}