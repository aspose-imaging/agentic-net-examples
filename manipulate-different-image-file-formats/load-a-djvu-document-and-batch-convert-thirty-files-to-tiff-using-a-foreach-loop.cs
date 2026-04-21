using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative to current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Get all DjVu files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

        int processed = 0;
        foreach (string inputPath in files)
        {
            // Stop after processing thirty files
            if (processed >= 30)
                break;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output path with .tif extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options (default format)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Export all pages of the DjVu document to a multi‑page TIFF
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save the TIFF file
                djvuImage.Save(outputPath, tiffOptions);
            }

            processed++;
        }
    }
}