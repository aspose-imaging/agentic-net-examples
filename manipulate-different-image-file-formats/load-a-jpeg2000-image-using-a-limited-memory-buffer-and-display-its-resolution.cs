using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set a memory buffer limit (e.g., 10 MB)
            var loadOptions = new Jpeg2000LoadOptions
            {
                BufferSizeHint = 10
            };

            // Load the JPEG2000 image with limited memory buffer
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Cast to Jpeg2000Image to access resolution properties
                var jpeg2000Image = (Jpeg2000Image)image;

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
 * 1. When a C# application must read large JPEG2000 medical images on a low‑memory server and needs to know the image DPI for accurate scaling.
 * 2. When a .NET service processes satellite JPEG2000 tiles and wants to limit memory usage while extracting horizontal and vertical resolution for georeferencing.
 * 3. When a desktop utility converts JPEG2000 scans to PDF and must verify the original resolution before embedding the image.
 * 4. When a batch job validates archival JPEG2000 files by loading them with a buffer size hint and checking their DPI to ensure compliance with printing standards.
 * 5. When a web API receives JPEG2000 uploads, loads them with a constrained memory buffer, and returns the image resolution to the client for preview layout calculations.
 */