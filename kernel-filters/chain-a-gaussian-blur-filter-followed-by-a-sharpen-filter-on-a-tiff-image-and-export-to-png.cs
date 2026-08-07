using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce noise in a high‑resolution scanned TIFF document, apply a Gaussian blur followed by a sharpen filter, and then convert it to a web‑friendly PNG for display in a browser.
 * 2. When building a C# batch‑processing tool that prepares archival TIFF images for an online gallery, the code can smooth the image, enhance edges, and export the result as PNG.
 * 3. When integrating Aspose.Imaging into a medical imaging workflow to preprocess TIFF X‑ray scans—softening grainy areas with Gaussian blur, sharpening diagnostic details, and saving as PNG for electronic health records.
 * 4. When creating a document‑conversion service that receives multi‑page TIFF files, applies a blur‑then‑sharpen effect to improve visual quality, and returns a single PNG thumbnail to the client.
 * 5. When developing a C# desktop application that lets users clean up scanned receipts (TIFF), automatically applies a blur‑sharpen sequence to improve readability, and saves the cleaned image as PNG for OCR processing.
 */