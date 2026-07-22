using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set BMP save options with 24 bits per pixel
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 24
                        };

                        // Save the page as BMP using the specified options
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and store them as high‑color BMP files for legacy Windows applications.
 * 2. When an archival system requires converting scanned DjVu files into 24‑bit BMP images to preserve visual fidelity before performing OCR.
 * 3. When a printing workflow must generate BMP assets from DjVu source files so that downstream raster image processors can handle a fixed bits‑per‑pixel format.
 * 4. When a document‑management tool needs to create thumbnail previews by saving DjVu pages as BMP with 24‑bit color depth for consistent display across platforms.
 * 5. When a batch‑processing script has to automate the conversion of DjVu e‑books into BMP images for compatibility with software that only supports BMP input.
 */