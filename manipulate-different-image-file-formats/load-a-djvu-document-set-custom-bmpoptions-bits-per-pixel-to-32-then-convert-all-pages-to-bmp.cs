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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.djvu";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (will be created if missing)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the document
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build the output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure BMP options with 32 bits per pixel
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 32
                        };

                        // Save the page as a BMP image
                        page.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract high‑resolution bitmap images from a multi‑page DjVu archive for use in a Windows desktop application, they can load the DjVu document with Aspose.Imaging, set BmpOptions BitsPerPixel to 32, and save each page as a 32‑bit BMP file.
 * 2. When a document‑management system must convert scanned DjVu files into lossless BMP images to preserve color depth before performing OCR or archival storage, this C# code provides a straightforward batch conversion.
 * 3. When a publishing workflow requires converting DjVu e‑books into BMP pages for inclusion in a print‑ready PDF pipeline, the code demonstrates how to iterate through DjVu pages and generate 32‑bit BMPs with Aspose.Imaging.
 * 4. When a developer is building a migration tool that moves legacy DjVu technical manuals to a format compatible with older Windows imaging tools, the example shows how to read the DjVu stream and output each page as a 32‑bit BMP.
 * 5. When an automated server process must generate thumbnail previews of DjVu documents by first converting pages to high‑quality BMPs and then resizing them, this snippet illustrates the initial step of creating 32‑bit BMP files from each DjVu page.
 */