using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\portion.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Get the first page of the document
                DjvuPage page = djvuImage.FirstPage;

                // Define the rectangle area to extract (x, y, width, height)
                Rectangle rect = new Rectangle(50, 50, 300, 300);

                // Save the specified portion as PNG
                page.Save(outputPath, new PngOptions(), rect);
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
 * 1. When a developer needs to extract a specific region from a multi‑page DjVu document and save it as a PNG thumbnail for a web preview.
 * 2. When an application must generate a high‑resolution PNG snippet of a scanned map stored in DjVu format for GIS analysis.
 * 3. When a document management system requires converting a selected area of a DjVu invoice into a PNG image for OCR processing.
 * 4. When a digital publishing workflow extracts a logo or diagram from a DjVu manuscript and outputs it as a PNG asset for reuse.
 * 5. When a C# service creates a PNG preview of a user‑defined rectangle within a DjVu file to display a focused view in a UI.
 */