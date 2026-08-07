using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.jp2";
            string outputPath = "output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load JPEG2000 image with limited memory buffer (10 MB hint)
            var loadOptions = new Aspose.Imaging.ImageLoadOptions.Jpeg2000LoadOptions
            {
                BufferSizeHint = 10
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var jpeg2000Image = image as Jpeg2000Image;
                if (jpeg2000Image != null)
                {
                    Console.WriteLine($"Width: {jpeg2000Image.Width}");
                    Console.WriteLine($"Height: {jpeg2000Image.Height}");
                    Console.WriteLine($"Horizontal Resolution: {jpeg2000Image.HorizontalResolution}");
                    Console.WriteLine($"Vertical Resolution: {jpeg2000Image.VerticalResolution}");
                }
                else
                {
                    Console.Error.WriteLine("Failed to cast loaded image to Jpeg2000Image.");
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
 * 1. When a medical imaging application needs to quickly read a large JPEG2000 radiology scan on a low‑memory server and log its pixel dimensions and DPI for downstream analysis.
 * 2. When a GIS tool processes satellite JPEG2000 tiles on a mobile device and must limit RAM usage while extracting image resolution to correctly overlay map layers.
 * 3. When an e‑commerce platform imports high‑resolution product photos stored as JPEG2000 and wants to verify their width, height, and resolution before generating thumbnails in a constrained Azure Function.
 * 4. When a digital archiving system validates scanned documents saved in JPEG2000 format by loading them with a 10 MB buffer and recording their resolution to ensure compliance with archival standards.
 * 5. When a printing workflow software reads a JPEG2000 artwork file on a thin client, uses a limited memory buffer to avoid crashes, and displays the image’s horizontal and vertical resolution to confirm print quality settings.
 */