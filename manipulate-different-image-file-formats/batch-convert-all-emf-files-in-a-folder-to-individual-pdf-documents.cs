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
            string inputFolder = @"C:\InputEmf";
            string outputFolder = @"C:\OutputPdf";

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PDF output path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image and save it as PDF
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
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