using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Setup input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // Process each TIFF file
        foreach (var file in files)
        {
            // Filter for TIFF extensions
            if (!(file.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                  file.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            string inputPath = file;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputFileName = Path.GetFileNameWithoutExtension(file) + ".pdf";
            string outputPath = Path.Combine(outputDirectory, outputFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Deskew the image
                tiff.NormalizeAngle(false, Color.White);

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiff.Save(outputPath, pdfOptions);
            }
        }
    }
}