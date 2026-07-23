using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesUpper = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesUpper.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesUpper.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
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
                    // Cast to TiffImage to access AdjustGamma
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.AdjustGamma(1.3f);

                    // Prepare output PDF path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
                    tiffImage.Save(outputPath, new PdfOptions());
                }
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
 * 1. When a developer needs to batch‑process a folder of scanned TIFF documents to improve their brightness by applying a gamma of 1.3 and then archive them as searchable PDF files using C# and Aspose.Imaging.
 * 2. When an imaging workflow requires automatically converting legacy medical TIFF images to PDF while correcting exposure through gamma adjustment to meet regulatory compliance.
 * 3. When a document management system must ingest multiple high‑resolution TIFF files, normalize their contrast with a gamma of 1.3, and store the results as PDF for easier viewing on web browsers.
 * 4. When a batch conversion tool is built in .NET to prepare photographic TIFF assets for printing by applying gamma correction and outputting them as PDF portfolios.
 * 5. When a developer wants to create a scheduled job that scans a directory for *.tif and *.tiff files, adjusts their gamma, and saves each image as a PDF in a separate output folder using Aspose.Imaging.
 */