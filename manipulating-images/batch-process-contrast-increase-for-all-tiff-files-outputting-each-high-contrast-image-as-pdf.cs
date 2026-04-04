using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative to current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Get all TIFF files in the input directory
        string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

        foreach (string inputPath in tiffFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output PDF path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load TIFF image, adjust contrast, and save as PDF
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;
                tiffImage.AdjustContrast(50f); // Increase contrast
                tiffImage.Save(outputPath, new PdfOptions());
            }
        }
    }
}