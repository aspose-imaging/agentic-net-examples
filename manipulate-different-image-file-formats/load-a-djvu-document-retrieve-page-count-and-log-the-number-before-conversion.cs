using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Log the total number of pages before any conversion
                Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                // Convert each page to PNG
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract the total number of pages from a DjVu document before converting each page to PNG for further processing or display.
 * 2. When an application must verify the existence of a DjVu file, load it via a FileStream, and log its page count to ensure the document is complete before batch conversion.
 * 3. When a document management system requires converting multi‑page DjVu files into individual PNG images while preserving page order and reporting the page count for indexing.
 * 4. When a C# service automates image preprocessing by reading DjVu archives, logging the page count for monitoring, and saving each page as a high‑resolution PNG in a structured output folder.
 * 5. When a developer builds a workflow that needs to read DjVu files, determine how many pages they contain, and then generate separate PNG files for each page for use in web galleries or OCR pipelines.
 */