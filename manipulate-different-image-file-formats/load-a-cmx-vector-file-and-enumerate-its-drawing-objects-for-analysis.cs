// HOW-TO: How To Load A CMX File And List Its Pages In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputPath = "analysis.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Cache data for the main image
                cmx.CacheData();

                // Access the CMX document (full namespace used to avoid extra using)
                var document = cmx.Document; // type: Aspose.Imaging.FileFormats.Cmx.ObjectModel.CmxDocument

                Console.WriteLine("CMX Document analysis:");
                Console.WriteLine($"Total pages: {cmx.Pages.Length}");

                int pageIndex = 0;
                foreach (var page in cmx.Pages)
                {
                    // Each page is a CmxImagePage
                    var cmxPage = (CmxImagePage)page;
                    cmxPage.CacheData();

                    Console.WriteLine($"Page {pageIndex}: Size = {cmxPage.Size.Width}x{cmxPage.Size.Height}");

                    // Access the underlying CmxPage object (drawing objects can be inspected via this)
                    var cmxPageObject = cmxPage.CmxPage; // type: Aspose.Imaging.FileFormats.Cmx.ObjectModel.CmxPage
                    Console.WriteLine($"  CmxPage type: {cmxPageObject.GetType().FullName}");

                    // Placeholder for further drawing object enumeration if needed
                    // e.g., iterate over cmxPageObject.Objects (if such a collection exists)

                    pageIndex++;
                }

                // Write a simple report to the output file
                File.WriteAllText(outputPath, $"CMX analysis completed. Pages processed: {pageIndex}");
                Console.WriteLine($"Analysis report saved to: {outputPath}");
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
 * 1. When you need to read a CorelDRAW CMX vector file in a .NET application to extract page dimensions for layout validation.
 * 2. When you want to generate a textual report of all pages in a CMX document for automated quality‑control pipelines.
 * 3. When you must programmatically verify that a CMX file contains the expected number of pages before converting it to another format.
 * 4. When you are building a tool that inspects drawing objects inside each CMX page to gather metadata for asset management.
 * 5. When you need to ensure a CMX file is accessible and its page information can be logged for debugging image‑processing workflows.
 */
