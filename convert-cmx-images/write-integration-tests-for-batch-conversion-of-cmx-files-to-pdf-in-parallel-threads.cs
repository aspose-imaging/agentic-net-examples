using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDir = Path.Combine(baseDir, "Input");
        string outputDir = Path.Combine(baseDir, "Output");

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all CMX files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.cmx");

        // Process each file in parallel
        files.AsParallel().ForAll(inputPath =>
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine the output PDF path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + ".pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image and save as PDF
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        });
    }
}