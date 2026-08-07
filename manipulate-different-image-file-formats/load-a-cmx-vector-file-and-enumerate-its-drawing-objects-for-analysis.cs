using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output\\cmx_analysis.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Access the CMX document (full namespace used to avoid extra using)
                var document = image.Document; // Aspose.Imaging.FileFormats.Cmx.ObjectModel.CmxDocument

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine($"CMX file: {inputPath}");
                    writer.WriteLine($"Page count: {image.PageCount}");

                    int pageIndex = 0;
                    foreach (var page in image.Pages)
                    {
                        writer.WriteLine($"Page {pageIndex}: Width={page.Width}, Height={page.Height}");
                        pageIndex++;
                    }
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
 * 1. When a developer needs to extract metadata such as page count and dimensions from a CorelDRAW CMX vector file using Aspose.Imaging for .NET to populate a document management system.
 * 2. When a developer wants to generate a plain‑text report of each CMX page’s width and height in a C# application before converting the file to another format like PDF.
 * 3. When a developer must verify that a CMX file can be loaded and its pages enumerated with the CmxImage class as part of an automated batch‑processing pipeline.
 * 4. When a developer is creating a quality‑assurance tool that logs CMX drawing object information to a .txt file for review in a printing workflow.
 * 5. When a developer requires a simple C# script to enumerate CMX pages and write their properties to a file for downstream analytics or archival purposes.
 */