using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EPS file paths
            string[] inputPaths = { "input1.eps", "input2.eps", "input3.eps" };
            // Hardcoded output PDF path
            string outputPath = "merged.pdf";

            // Validate each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure the output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load all EPS images into a list
            var images = new List<Image>();
            foreach (var path in inputPaths)
            {
                Image img = Image.Load(path);
                images.Add(img);
            }

            // Create a multipage image from the loaded EPS images
            using (Image result = Image.Create(images.ToArray(), true))
            {
                // Save the combined image as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                result.Save(outputPath, pdfOptions);
            }

            // Dispose the individually loaded images
            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. A graphic designer automates the creation of a single PDF portfolio by converting multiple EPS artwork files into a multi‑page document with page‑level bookmarks using Aspose.Imaging for .NET.
 * 2. An engineering firm merges a series of EPS circuit diagrams into one searchable PDF report, enabling quick navigation to each diagram via automatically generated bookmarks.
 * 3. A marketing team batches EPS logo files into a consolidated PDF brochure, allowing clients to preview each logo on separate bookmarked pages without manual PDF editing.
 * 4. A legal department archives EPS‑based contract illustrations by programmatically converting them to a single PDF file, preserving vector quality and adding bookmarks for easy reference.
 * 5. A software vendor generates printable user manuals by stitching EPS UI screenshots into a multi‑page PDF, with each screenshot bookmarked for rapid access during documentation reviews.
 */