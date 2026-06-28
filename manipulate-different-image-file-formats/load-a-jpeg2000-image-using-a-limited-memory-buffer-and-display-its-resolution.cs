using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.jp2";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set limited memory buffer (e.g., 1 MB)
            var loadOptions = new Jpeg2000LoadOptions
            {
                BufferSizeHint = 1024 * 1024
            };

            // Load the JPEG2000 image with the specified options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Cast to Jpeg2000Image to access resolution properties
                var jpeg2000Image = image as Jpeg2000Image;
                if (jpeg2000Image == null)
                {
                    Console.Error.WriteLine("Loaded image is not a JPEG2000 image.");
                    return;
                }

                // Display horizontal and vertical resolution (DPI)
                Console.WriteLine($"Horizontal resolution: {jpeg2000Image.HorizontalResolution} DPI");
                Console.WriteLine($"Vertical resolution: {jpeg2000Image.VerticalResolution} DPI");
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
 * 1. When a C# application must read large JPEG2000 medical images on a low‑memory server and verify their DPI before processing them further.
 * 2. When a desktop utility needs to quickly show the horizontal and vertical resolution of a JP2 file without loading the entire image into memory.
 * 3. When a batch‑processing script validates that scanned engineering drawings stored as JPEG2000 meet the required resolution standards while operating under a 1 MB buffer limit.
 * 4. When a cloud‑based image‑conversion service reads JPEG2000 assets with a memory‑size hint to avoid out‑of‑memory errors and logs their DPI for quality‑control reports.
 * 5. When a GIS tool imports JP2 satellite tiles, reads their resolution metadata, and ensures they match the map’s scale while using limited RAM.
 */