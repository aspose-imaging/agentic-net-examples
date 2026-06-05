using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            int index = 1;
            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path with sequential numeric suffix
                string outputFileName = $"output_{index}.pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }

                index++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}