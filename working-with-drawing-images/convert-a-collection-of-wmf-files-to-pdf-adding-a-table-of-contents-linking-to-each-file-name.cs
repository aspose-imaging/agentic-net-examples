using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf; // Namespace for PdfCoreOptions and PdfDocumentInfo

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputPdf";

            // Collection of WMF file names to process
            string[] wmfFiles = new[]
            {
                "Sample1.wmf",
                "Sample2.wmf",
                "Sample3.wmf"
            };

            foreach (string fileName in wmfFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputFolder, fileName);
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(fileName) + ".pdf");

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (Image wmfImage = Image.Load(inputPath))
                {
                    // Configure PDF options with a bookmark for the file name
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            // Enable a single level of bookmarks (outline)
                            BookmarksOutlineLevel = 1
                        },
                        // Set document title – this will appear as a bookmark entry
                        PdfDocumentInfo = new PdfDocumentInfo
                        {
                            Title = Path.GetFileNameWithoutExtension(fileName)
                        }
                    };

                    // Save the image as a PDF page
                    wmfImage.Save(outputPath, pdfOptions);
                }
            }

            // Simple console TOC listing the generated PDFs
            Console.WriteLine("Table of Contents:");
            foreach (string fileName in wmfFiles)
            {
                string pdfName = Path.GetFileNameWithoutExtension(fileName) + ".pdf";
                Console.WriteLine($"- {pdfName}");
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
 * 1. When a developer needs to batch‑convert legacy Windows Metafile (WMF) drawings into searchable PDF reports with a clickable table of contents that links each PDF page to its original file name.
 * 2. When an engineering team wants to archive a collection of schematic WMF files as a single PDF portfolio, preserving the file names as bookmarks for quick navigation.
 * 3. When a documentation system must automatically generate PDF manuals from WMF icons and diagrams, adding outline entries so readers can jump directly to each diagram.
 * 4. When a financial application needs to transform multiple WMF charts into PDF pages and provide a navigable index for auditors to locate each chart by its source name.
 * 5. When a content‑management workflow requires converting WMF assets to PDF while programmatically creating a table of contents using Aspose.Imaging’s PdfOptions and PdfDocumentInfo features.
 */