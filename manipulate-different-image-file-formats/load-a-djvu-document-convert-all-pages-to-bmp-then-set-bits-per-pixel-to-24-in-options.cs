// HOW-TO: Convert DjVu Pages to 24‑Bit BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.djvu";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (will be created for each file as well)
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Convert the page to a BMP image with 24 bits per pixel
                    // Using the BmpImage constructor that accepts a raster image, bits per pixel, compression, and resolution
                    using (BmpImage bmp = new BmpImage(
                        (RasterImage)page,               // source raster image (the Djvu page)
                        24,                              // bits per pixel
                        BitmapCompression.Rgb,          // no compression
                        96.0,                            // horizontal resolution (dpi)
                        96.0))                           // vertical resolution (dpi)
                    {
                        // Save the BMP image to the specified path
                        bmp.Save(outputPath);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑quality 24‑bit BMP files for further editing in graphic software.
 * 2. When an application must convert scanned DjVu documents into BMP format to preserve color depth for accurate printing or archival.
 * 3. When a .NET service processes user‑uploaded DjVu files and generates BMP thumbnails with full color information for preview galleries.
 * 4. When migrating legacy DjVu assets to a Windows‑compatible bitmap format without losing color fidelity in a batch conversion routine.
 * 5. When integrating Aspose.Imaging into a workflow that requires converting DjVu pages to uncompressed BMP images for pixel‑level analysis or computer‑vision tasks.
 */
