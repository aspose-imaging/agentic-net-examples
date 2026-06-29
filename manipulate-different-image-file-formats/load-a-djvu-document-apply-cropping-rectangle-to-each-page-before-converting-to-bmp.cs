using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "input.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for BMP files
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Ensure each page is disposed after processing
                        using (page)
                        {
                            // Define cropping rectangle (example values)
                            Rectangle cropRect = new Rectangle(50, 50, 200, 200);
                            page.Crop(cropRect);

                            // Build output BMP file path for the current page
                            string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the cropped page as BMP
                            BmpOptions bmpOptions = new BmpOptions();
                            page.Save(outputPath, bmpOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each page from a multi‑page DjVu document, crop a specific region, and save the result as BMP files for legacy Windows applications.
 * 2. When an archival system must convert scanned DjVu files into BMP thumbnails with a fixed viewport to display in a .NET web portal.
 * 3. When a document‑processing pipeline requires batch processing of DjVu reports, removing margins via a cropping rectangle before converting them to BMP for OCR engines that only accept BMP input.
 * 4. When a desktop utility has to read a DjVu file from a stream, isolate a region of interest on every page, and output BMP images for further editing in graphic design tools.
 * 5. When a C# application automates the preparation of DjVu e‑books for printing by cropping each page to the printable area and exporting the result as BMP files for a print‑ready workflow.
 */