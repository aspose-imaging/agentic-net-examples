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

        // Get all TIFF files in the input folder
        string[] files = Directory.GetFiles(inputDirectory, "*.tif");
        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Adjust brightness (example value: 50)
                tiffImage.AdjustBrightness(50);

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiffImage.Save(outputPath, pdfOptions);
            }
        }
    }
}