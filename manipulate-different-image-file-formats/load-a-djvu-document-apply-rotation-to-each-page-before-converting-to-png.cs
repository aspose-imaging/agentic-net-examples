// HOW-TO: Rotate Each Page of a DjVu Document and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page, rotate, and save as PNG
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Rotate the page (e.g., 90 degrees clockwise, resize proportionally, white background)
                    page.Rotate(90f, true, Aspose.Imaging.Color.White);

                    // Prepare output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the rotated page as PNG
                    page.Save(outputPath, new PngOptions());
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
 * 1. When you need to display scanned DjVu pages in a web viewer that only supports PNG, you can rotate and convert each page to PNG.
 * 2. When processing multi‑page DjVu files from a scanner and the pages are oriented incorrectly, you can programmatically rotate them before converting to PNG for archival.
 * 3. When creating thumbnails for a DjVu e‑book and want them uniformly oriented, you can rotate each page and export as PNG using Aspose.Imaging in C#.
 * 4. When integrating a document‑conversion service that receives DjVu uploads and must output correctly oriented PNG images for downstream OCR pipelines.
 * 5. When building a batch job that extracts each page of a DjVu file, applies a 90‑degree rotation, and stores the results as PNG files for printing or further image analysis.
 */
