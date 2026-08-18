// HOW-TO: Extract Text From CMX File To Plain Text For Indexing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\output.txt";

            // Verify that the input CMX file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image using Aspose.Imaging
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Extract textual representation of the CMX document
                string extractedText = image.Document.ToString();

                // Write the extracted text to the plain‑text output file
                File.WriteAllText(outputPath, extractedText);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to index the textual content of legacy CorelDRAW CMX drawings for a search engine or document repository.
 * 2. When building a batch process that converts multiple CMX design files into searchable plain‑text files for metadata extraction.
 * 3. When integrating Aspose.Imaging into a C# application to harvest embedded text from CMX files for content analysis or compliance reporting.
 * 4. When automating the preparation of CMX assets for full‑text indexing in SharePoint or Elasticsearch without manual copy‑paste.
 * 5. When creating a migration tool that reads CMX documents and stores their text in a database to enable keyword‑based retrieval.
 */
