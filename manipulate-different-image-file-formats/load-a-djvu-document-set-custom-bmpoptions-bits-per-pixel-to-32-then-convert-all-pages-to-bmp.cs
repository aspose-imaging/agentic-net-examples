// HOW-TO: Convert DjVu Document Pages to 32‑Bit BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory
            string outputDir = "output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build the output BMP file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists (covers nested paths)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure BMP options with 32 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };

                    // Save the current page as a BMP file using the specified options
                    page.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑color‑depth BMP files for legacy Windows applications.
 * 2. When converting scanned DjVu archives into 32‑bit BMP images to preserve image quality before performing OCR or further processing.
 * 3. When preparing DjVu documents for printing on devices that only accept BMP format with full alpha channel support.
 * 4. When batch‑processing DjVu manuals into BMP thumbnails for inclusion in a .NET desktop catalog viewer.
 * 5. When migrating DjVu assets to a BMP‑based workflow in a C# project using Aspose.Imaging to ensure consistent pixel depth across all pages.
 */
