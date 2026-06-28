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
            string outputPath = "extracted_text.txt";

            // Validate input file existence
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
                // Extract textual representation of the document
                string extractedText = cmx.Document?.ToString() ?? string.Empty;

                // Write extracted text to output file
                File.WriteAllText(outputPath, extractedText);
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
 * 1. When a developer needs to index the textual content of legacy CorelDRAW CMX files for a search engine, they can extract the text to a .txt file using Aspose.Imaging for .NET.
 * 2. When building a document management system that must archive CMX drawings and make their annotations searchable, the code can pull the document’s text and store it in a plain‑text index.
 * 3. When migrating old CMX graphics into a modern content‑management workflow, a developer can use this snippet to convert embedded text into searchable plain‑text files for metadata extraction.
 * 4. When creating a batch‑processing tool that scans a folder of CMX files and generates keyword lists for SEO or compliance reporting, the code provides a quick way to write each file’s text to a .txt output.
 * 5. When integrating CMX support into an enterprise search platform, a developer can run this routine to feed the extracted strings into the indexing pipeline via simple C# file I/O operations.
 */