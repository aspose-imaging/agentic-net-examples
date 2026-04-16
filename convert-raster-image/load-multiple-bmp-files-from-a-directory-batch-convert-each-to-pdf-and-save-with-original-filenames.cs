using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all BMP files in the input directory
        string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

        foreach (string inputPath in bmpFiles)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output PDF path using the original file name
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image and save it as PDF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }
        }
    }
}