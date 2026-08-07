using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input PDF path
            string inputPath = @"C:\temp\input.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where the TIFF files will be written
            string outputDirectory = @"C:\temp\output";

            // Export pages 1‑3 (zero‑based indices 0,1,2) as separate TIFF files
            for (int pageIndex = 0; pageIndex < 3; pageIndex++)
            {
                // Build output file name (e.g., page1.tif, page2.tif, page3.tif)
                string outputPath = Path.Combine(outputDirectory, $"page{pageIndex + 1}.tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PDF image
                using (Image pdfImage = Image.Load(inputPath))
                {
                    // Configure TIFF save options with a page range containing only the current page
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        MultiPageOptions = new MultiPageOptions(new int[] { pageIndex })
                    };

                    // Save the selected page as a single‑frame TIFF
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
 * 1. When a developer needs to extract the first three pages of a multi‑page PDF and store each page as an individual TIFF file for archival or printing workflows using Aspose.Imaging for .NET.
 * 2. When an application must convert specific PDF pages to single‑frame TIFF images to feed into a legacy document management system that only accepts TIFF format.
 * 3. When a batch process has to generate separate high‑resolution TIFFs from selected PDF pages for OCR preprocessing in a C# service.
 * 4. When a developer wants to create page‑by‑page TIFF thumbnails from a PDF to display in a web portal that lists each page as an image.
 * 5. When a compliance tool must isolate the first three pages of a contract PDF and save them as separate TIFF files for digital signature verification.
 */