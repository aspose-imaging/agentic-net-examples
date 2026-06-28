using System;
using System.IO;
using System.Linq;
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
            string inputDir = "C:\\InputTiffs\\";
            string outputDir = "C:\\OutputPdfs\\";

            // Collect all TIFF files (both .tif and .tiff)
            var tiffFiles = Directory.GetFiles(inputDir, "*.tif")
                .Concat(Directory.GetFiles(inputDir, "*.tiff"));

            foreach (var inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path with same base name
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, apply gamma correction, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.AdjustGamma(1.3f);
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
 * 1. When a developer needs to automatically enhance the brightness of scanned documents by applying a gamma correction of 1.3 to every TIFF file in a folder and then archive them as searchable PDFs.
 * 2. When a batch conversion tool must process a large collection of medical imaging TIFFs, adjust their contrast with gamma 1.3, and output compliant PDF reports for electronic health records.
 * 3. When an archival system requires converting legacy TIFF photographs from a directory into PDF format while improving visual quality through gamma correction before storage.
 * 4. When a document management workflow automates the preparation of TIFF‑based invoices, applying gamma 1.3 to ensure readability and saving each as a PDF for downstream processing.
 * 5. When a C# application needs to scan a directory for .tif and .tiff files, perform image processing (gamma adjustment) and generate PDF versions for easy distribution to clients.
 */