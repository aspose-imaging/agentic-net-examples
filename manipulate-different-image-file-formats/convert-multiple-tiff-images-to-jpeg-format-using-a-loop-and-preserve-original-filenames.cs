using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in tiffFiles)
            {
                // Process only .tif or .tiff extensions (case‑insensitive)
                string extension = Path.GetExtension(filePath);
                if (!extension.Equals(".tif", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Build output path with same filename but .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(filePath))
                {
                    // Save as JPEG using default options
                    image.Save(outputPath, new JpegOptions());
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
 * 1. When a medical imaging system stores patient scans as high‑resolution TIFF files and needs to generate smaller JPEG copies for quick web viewing while keeping the original scan names.
 * 2. When a publishing workflow receives bulk TIFF artwork from designers and must create JPEG previews for editorial review without altering the original filenames.
 * 3. When an e‑commerce platform imports product photos in TIFF format and wants to batch‑convert them to JPEG for faster page loads while preserving the SKU‑based file names.
 * 4. When a digital archiving tool processes scanned documents saved as TIFF and needs to produce JPEG versions for email distribution, maintaining the same document identifiers.
 * 5. When a GIS application exports map tiles as TIFF and requires a script to generate JPEG tiles for mobile apps, keeping each tile’s original name for seamless integration.
 */