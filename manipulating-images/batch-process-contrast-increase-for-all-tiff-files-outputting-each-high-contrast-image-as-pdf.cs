// HOW-TO: Increase Contrast of Multiple TIFF Images and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDir, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same name, .pdf extension) in the output directory
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, adjust contrast, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Increase contrast (value in range [-100, 100])
                    tiffImage.AdjustContrast(50f);

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
 * 1. When a company needs to batch‑enhance the contrast of scanned TIFF documents to make text clearer before converting them to PDF archives.
 * 2. When a developer wants to automate the preparation of high‑contrast TIFF graphics for inclusion in PDF reports.
 * 3. When an application must process a folder of medical TIFF scans, improve their visual quality, and output each as a PDF for electronic health records.
 * 4. When a digital‑preservation workflow requires converting legacy TIFF photographs with boosted contrast into PDF format for easier distribution.
 * 5. When a developer is building a tool that reads TIFF files, adjusts their contrast using Aspose.Imaging, and saves the results as PDFs for downstream processing.
 */
