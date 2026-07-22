using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get DjVu files from the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");
            int processed = 0;

            foreach (string inputPath in files)
            {
                if (processed >= 30)
                    break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(); // Export all pages
                    djvuImage.Save(outputPath, tiffOptions);
                }

                processed++;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a legal firm needs to archive scanned case files originally stored as DjVu into multi‑page TIFFs for compatibility with their document management system, this code can batch‑process up to thirty files at a time.
 * 2. When a publishing house wants to convert a batch of DjVu e‑books into high‑resolution TIFF images for print‑ready proofing, the foreach loop automates the conversion of the first thirty documents.
 * 3. When a government agency must migrate historical DjVu maps into TIFF format for GIS software that only accepts TIFF, this snippet provides a quick C# solution to handle thirty files per run.
 * 4. When a medical records department receives patient scans in DjVu and needs to store them as TIFF for integration with PACS, the code batch processes up to thirty files while preserving all pages.
 * 5. When a cloud‑based image‑processing service offers an API to transform DjVu uploads into multi‑page TIFFs, developers can embed this loop to limit each job to thirty files for efficient resource management.
 */