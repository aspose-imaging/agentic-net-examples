using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputPngs";
        string outputDirectory = "OutputPdfs";

        // Validate input directory existence
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
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
            // Process only PNG files
            if (!string.Equals(Path.GetExtension(inputPath), ".png", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 500x500 pixels
                image.Resize(500, 500);

                // Prepare output PDF path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PDF using PdfOptions
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}