using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input DjVu file (hard‑coded path)
            string inputPath = "Input\\sample.djvu";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for BMP files (hard‑coded path)
            string outputDir = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Configure BMP save options with 32 bits per pixel
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build the output file name for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a BMP using the configured options
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
 * 1. When a document management system needs to archive scanned DjVu files as high‑color BMP images for compatibility with legacy Windows applications.
 * 2. When a digital publishing workflow requires extracting each page of a multi‑page DjVu e‑book and saving them as 32‑bit BMP files for further editing in graphic design tools.
 * 3. When a legal firm must convert confidential DjVu case files into lossless BMP format with 32 bits per pixel to preserve image fidelity for courtroom presentations.
 * 4. When a medical imaging platform processes DjVu‑encoded patient records and generates BMP pages to integrate with a C#‑based reporting module that only accepts BMP inputs.
 * 5. When an archival project automates the batch conversion of DjVu archives into BMP files to ensure long‑term storage in a widely supported raster format using Aspose.Imaging for .NET.
 */