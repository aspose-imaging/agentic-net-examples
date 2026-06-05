using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file and output directory
            string inputPath = "sample.djvu";
            string outputDir = "Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Iterate through each page
                foreach (DjvuPage page in djvu.Pages)
                {
                    // Rotate page 90 degrees clockwise, resize proportionally, white background
                    page.Rotate(90f, true, Color.White);

                    // Build output file path for the page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");

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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document, rotate it for proper orientation, and save it as a high‑quality PNG for web preview.
 * 2. When an archival system must convert scanned DjVu files into PNG thumbnails while correcting a 90‑degree misalignment on every page.
 * 3. When a document‑processing pipeline requires batch conversion of DjVu pages to PNG images with a white background after rotating them to match portrait layout.
 * 4. When a digital publishing tool needs to programmatically load a DjVu ebook, rotate each page clockwise, and output PNG files for inclusion in an e‑reader app.
 * 5. When a C# application must validate the existence of a DjVu source, create an output folder, and transform each rotated page into PNG using Aspose.Imaging for further analysis.
 */