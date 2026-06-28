using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string cdrPath = "Input/sample.cdr";
            string tiffPath = "Input/sample.tif";
            string outputPath = "Output/combined.pdf";

            // Validate input files
            if (!File.Exists(cdrPath))
            {
                Console.Error.WriteLine($"File not found: {cdrPath}");
                return;
            }
            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source images
            using (Image cdrImage = Image.Load(cdrPath))
            using (Image tiffImage = Image.Load(tiffPath))
            {
                var pages = new List<Image>();

                // Extract pages from CDR image
                if (cdrImage is IMultipageImage cdrMulti && cdrMulti.Pages != null)
                {
                    foreach (Image page in cdrMulti.Pages)
                    {
                        pages.Add(page);
                    }
                }
                else
                {
                    pages.Add(cdrImage);
                }

                // Extract pages from TIFF image
                if (tiffImage is IMultipageImage tiffMulti && tiffMulti.Pages != null)
                {
                    foreach (Image page in tiffMulti.Pages)
                    {
                        pages.Add(page);
                    }
                }
                else
                {
                    pages.Add(tiffImage);
                }

                // Create a multipage image from collected pages
                using (Image multipage = Image.Create(pages.ToArray()))
                {
                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        // Use the size of the first page as a fallback
                        PageWidth = multipage.Width,
                        PageHeight = multipage.Height
                    };

                    // Save the combined multipage image as PDF
                    multipage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to merge design artwork stored in CorelDRAW (CDR) files with scanned documents in TIFF format into a single PDF report.
 * 2. When an application must programmatically combine multi‑page CDR drawings and multi‑page TIFF scans into a unified PDF for archival or distribution.
 * 3. When a workflow requires converting a multi‑page vector illustration and a multi‑page raster image into a searchable PDF without manual export.
 * 4. When a system automates the creation of client‑ready PDFs that include both editable CDR pages and high‑resolution TIFF pages for printing.
 * 5. When a developer wants to validate that all pages from different source formats (CDR and TIFF) are correctly loaded and concatenated into one PDF document using Aspose.Imaging for .NET.
 */