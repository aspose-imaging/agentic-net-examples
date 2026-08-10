// HOW-TO: Batch Apply Gamma Correction to TIFFs and Convert to PDF in C# (Aspose.Imaging for .NET)
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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each TIFF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.tif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PDF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, apply gamma correction, and save as PDF
                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;
                    tiffImage.AdjustGamma(1.3f);

                    // Save the corrected image as PDF
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
 * 1. When you need to improve the brightness of a large set of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When a medical imaging workflow requires applying a consistent gamma adjustment to radiology TIFF files and delivering the results in PDF format for reporting.
 * 3. When an e‑commerce platform wants to automatically enhance product scan TIFFs and generate PDF catalogs without manual editing.
 * 4. When a legal firm must batch‑process courtroom TIFF evidence images, correct their exposure, and store them as PDFs for case files.
 * 5. When a publishing system needs to convert a folder of high‑resolution TIFF illustrations with gamma correction into PDF pages for print layout.
 */
