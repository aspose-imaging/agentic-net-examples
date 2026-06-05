using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Cmx.ObjectModel;

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
                // Retrieve the CMX document
                CmxDocument document = cmx.Document;

                // Extract textual representation (placeholder for actual text extraction logic)
                string extractedText = document?.ToString() ?? string.Empty;

                // Write extracted text to the output file
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
 * 1. When a developer needs to index the textual metadata embedded in legacy CorelDRAW CMX vector files for a search engine, they can use this code to extract the strings and save them to a .txt file.
 * 2. When migrating an archive of CMX drawings to a document management system, the code helps pull out any searchable text so the files can be catalogued and retrieved later.
 * 3. When building a C# application that generates searchable PDFs from CMX artwork, extracting the text first allows the PDF creation process to include searchable layers.
 * 4. When performing automated quality‑control checks on CMX files, developers can extract the embedded text to verify spelling, terminology, or compliance before further processing.
 * 5. When creating a full‑text index for a corporate knowledge base that includes CMX design files, this snippet provides a simple way to dump the text into a plain‑text file for ingestion by indexing tools.
 */