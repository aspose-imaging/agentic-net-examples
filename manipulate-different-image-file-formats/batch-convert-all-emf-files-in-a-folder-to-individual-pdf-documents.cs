using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, and output directories (relative paths)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
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

        // Get all EMF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build the output PDF path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure the output directory exists (unconditional call)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }

            Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
        }
    }
}