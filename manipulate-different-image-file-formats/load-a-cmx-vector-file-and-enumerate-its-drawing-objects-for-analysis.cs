using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "sample.cmx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Enumerate pages
                Console.WriteLine($"CMX file loaded. Page count: {cmx.Pages.Length}");
                int pageIndex = 0;
                foreach (var page in cmx.Pages)
                {
                    var cmxPage = page as CmxImagePage;
                    if (cmxPage != null)
                    {
                        Console.WriteLine($"Page {pageIndex}: Size = {cmxPage.Size.Width}x{cmxPage.Size.Height}");
                        // Additional analysis of drawing objects could be added here if API provides access.
                    }
                    pageIndex++;
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
 * 1. When a developer needs to validate that a CMX vector file from a legacy CAD system was successfully imported before converting it to another format.
 * 2. When an application must generate a report of page dimensions for each page in a multi‑page CMX drawing to ensure they meet printing specifications.
 * 3. When a quality‑control tool has to verify the existence of a CMX file and enumerate its pages to detect missing or corrupted pages before batch processing.
 * 4. When a migration script extracts metadata such as page count and size from CMX files to populate a database that tracks vector assets for a design repository.
 * 5. When a developer builds a preview feature that reads a CMX file, lists its pages, and displays basic information to help users choose which page to render in a .NET imaging application.
 */