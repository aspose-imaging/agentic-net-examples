using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the TIFF image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Define a 200x200 rectangle starting at (0,0)
                var cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                tiffImage.Crop(cropArea);

                // Save the cropped result to a memory stream (PNG format)
                using (MemoryStream outputStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    tiffImage.Save(outputStream, pngOptions);

                    // The memory stream now contains the cropped image data.
                    // For demonstration, we can output its length.
                    Console.WriteLine($"Cropped image size in bytes: {outputStream.Length}");
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
 * 1. When a medical imaging application needs to extract a 200 × 200 pixel region from a high‑resolution TIFF scan and send the cropped PNG directly over a web API without writing intermediate files.
 * 2. When a document management system processes multi‑page TIFF invoices, crops the top‑left logo area, and stores the result in a memory stream for further PDF generation.
 * 3. When a GIS tool reads satellite TIFF tiles from a stream, isolates a 200 × 200 area of interest, and converts it to PNG for quick preview in a web map viewer.
 * 4. When an e‑commerce platform receives product TIFF images, trims a fixed thumbnail region and keeps the cropped image in memory to embed it in an email template.
 * 5. When a digital archiving service validates incoming TIFF files, extracts a 200 × 200 sample patch, and streams the PNG to a machine‑learning model for image quality analysis.
 */