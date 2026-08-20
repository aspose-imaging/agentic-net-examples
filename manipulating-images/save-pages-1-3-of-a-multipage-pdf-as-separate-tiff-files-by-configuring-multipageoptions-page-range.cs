// HOW-TO: Save Specific PDF Pages As Separate TIFF Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.pdf";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PDF image
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Save pages 1‑3 (zero‑based indices 0‑2) as separate TIFF files
                for (int pageIndex = 0; pageIndex < 3; pageIndex++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page{pageIndex + 1}.tif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure TIFF save options with MultiPageOptions for a single page
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        MultiPageOptions = new MultiPageOptions(new int[] { pageIndex })
                    };

                    // Save the selected page to TIFF
                    pdfImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract the first three pages of a multi‑page PDF and store each page as an individual TIFF for archival or printing workflows.
 * 2. When a document management system requires separate high‑resolution TIFF images for each PDF page to comply with OCR or scanning standards.
 * 3. When generating thumbnails or preview images from selected PDF pages and saving them in TIFF format for use in a .NET web application.
 * 4. When converting specific PDF pages to TIFF to embed them into a legacy reporting tool that only accepts single‑page TIFF files.
 * 5. When automating batch processing that isolates particular pages of PDFs and saves them as TIFFs for downstream image analysis or machine‑learning pipelines.
 */
