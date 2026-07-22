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
            // Input DJVU file path
            string inputPath = "Input/sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DJVU file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DJVU image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑convert a multi‑page DJVU document into individual PNG images for web preview while preserving the original file name in XMP metadata.
 * 2. When an archival system requires extracting each page of a scanned DJVU manuscript as high‑quality PNG files and tagging them with the source filename for traceability.
 * 3. When a digital publishing workflow must transform DJVU e‑books into PNG assets for mobile apps and embed XMP metadata to link each image back to its source document.
 * 4. When a document management solution automates the conversion of DJVU reports into PNG thumbnails and adds XMP metadata so search engines can index the original file reference.
 * 5. When a C# application processes legal DJVU files, converts every page to PNG for OCR processing, and records the original DJVU filename in XMP metadata for audit logs.
 */