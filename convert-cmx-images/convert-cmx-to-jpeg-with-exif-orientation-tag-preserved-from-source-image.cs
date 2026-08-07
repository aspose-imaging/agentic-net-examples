using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options to keep metadata (including EXIF if present)
                JpegOptions jpegOptions = new JpegOptions
                {
                    KeepMetadata = true
                };

                // Save as JPEG preserving metadata
                image.Save(outputPath, jpegOptions);
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
 * 1. When a digital asset management system receives legacy CorelDRAW CMX files and must generate web‑ready JPEG thumbnails while keeping the original EXIF orientation for correct display.
 * 2. When a photo‑editing workflow needs to batch‑convert client‑supplied CMX drawings to JPEG for inclusion in an online portfolio, preserving metadata so the images appear upright on mobile devices.
 * 3. When an e‑commerce platform imports product illustrations stored as CMX and converts them to JPEG for fast loading on product pages, while retaining the EXIF orientation tag to avoid rotated pictures.
 * 4. When a document‑generation service extracts embedded CMX graphics from legacy reports and saves them as JPEGs for PDF embedding, ensuring the orientation metadata is kept for accurate rendering.
 * 5. When a mobile app syncs design assets from a Windows workstation, converting CMX files to JPEG on the server side with Aspose.Imaging so the images retain their original orientation when viewed on the device.
 */