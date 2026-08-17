// HOW-TO: Increase TIFF Image Contrast by 30% and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.tif";
            string outputPath = @"C:\temp\sample_high_contrast.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustContrast
                TiffImage tiffImage = (TiffImage)image;

                // Increase contrast by 30 %
                tiffImage.AdjustContrast(30f);

                // Save the result as PDF
                tiffImage.Save(outputPath, new PdfOptions());
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
 * 1. When you need to enhance the readability of scanned TIFF documents by boosting contrast before archiving them as PDF files.
 * 2. When a web service must convert high‑resolution TIFF scans into searchable PDFs with improved visual quality.
 * 3. When preparing medical imaging files for patient reports, increasing contrast helps highlight diagnostic details before generating a PDF.
 * 4. When automating batch processing of archival photographs, adjusting contrast ensures the resulting PDFs display vivid colors.
 * 5. When integrating document workflows, you may need to programmatically raise TIFF contrast and output a PDF for downstream printing.
 */
