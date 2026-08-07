using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Cmx.ObjectModel;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cmx";
        string outputPath = @"C:\Data\extracted_text.txt";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Access the CMX document
                CmxDocument document = cmxImage.Document;

                // Convert the document to its string representation (contains text data)
                string extractedText = document.ToString();

                // Write the extracted text to the output file
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
 * 1. When a developer wants to extract all embedded text from a CorelDRAW CMX file using Aspose.Imaging for .NET and save it to a plain‑text file for search‑engine indexing.
 * 2. When a document‑management system must convert CMX drawings into searchable text records so that users can locate designs by keyword.
 * 3. When a migration tool needs to read CMX image metadata and export the textual content to a .txt file for archival or compliance purposes.
 * 4. When an automated batch process has to verify that a CMX file contains the expected annotations by extracting its text and comparing it with reference strings.
 * 5. When a content‑analysis pipeline requires converting CMX vector graphics into plain text to perform natural‑language processing or sentiment analysis on the embedded labels.
 */