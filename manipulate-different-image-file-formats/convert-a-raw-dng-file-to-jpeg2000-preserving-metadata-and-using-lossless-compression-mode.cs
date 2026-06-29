using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.dng";
        string outputPath = @"c:\temp\output.jp2";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Configure JPEG2000 options for lossless compression and metadata preservation
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    Irreversible = false,      // lossless DWT 5-3
                    KeepMetadata = true        // preserve original metadata
                };

                // Save as JPEG2000
                dngImage.Save(outputPath, jpeg2000Options);
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
 * 1. When a photography workflow requires converting RAW DNG files to JPEG2000 for archival storage while keeping EXIF metadata intact and using lossless compression.
 * 2. When a medical imaging application needs to transform high‑resolution DNG scans into JPEG2000 to reduce file size without sacrificing diagnostic detail and preserve patient metadata.
 * 3. When a digital asset management system must ingest RAW camera files and store them as JPEG2000 with lossless DWT compression for efficient retrieval and metadata search.
 * 4. When a satellite imagery processing pipeline converts raw DNG sensor data to JPEG2000 for transmission, ensuring lossless quality and retaining geospatial metadata.
 * 5. When a web service offers on‑the‑fly conversion of uploaded DNG photos to JPEG2000 for clients who need a standards‑compliant, metadata‑preserving, lossless image format.
 */