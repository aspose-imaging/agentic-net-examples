using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/source.png";
            string outputPath = "Output/result.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a raster image
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Create a JPEG2000 image from the raster image
                using (Jpeg2000Image jp2Image = new Jpeg2000Image(raster))
                {
                    // Configure lossless compression and memory buffer limit
                    Jpeg2000Options saveOptions = new Jpeg2000Options
                    {
                        // Irreversible = false (default) ensures lossless compression
                        BufferSizeHint = 50 // memory limit in megabytes
                    };

                    // Save the JPEG2000 image
                    jp2Image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to archive high‑resolution PNG graphics in a space‑efficient, lossless JPEG2000 format for long‑term storage while controlling memory usage during conversion.
 * 2. When a medical imaging application must convert diagnostic PNG scans to JPEG2000 to meet DICOM standards without losing pixel data and with a strict memory buffer limit.
 * 3. When an e‑learning platform wants to serve printable course diagrams as JPEG2000 files to reduce bandwidth while preserving exact visual fidelity and avoiding out‑of‑memory errors.
 * 4. When a GIS system requires converting raster PNG map tiles to JPEG2000 for faster loading on thin clients, ensuring lossless compression and limiting the conversion process to 50 MB of RAM.
 * 5. When a digital publishing workflow needs to batch‑process PNG artwork into JPEG2000 for archival PDFs, using C# and Aspose.Imaging to enforce lossless quality and a predefined memory buffer size.
 */