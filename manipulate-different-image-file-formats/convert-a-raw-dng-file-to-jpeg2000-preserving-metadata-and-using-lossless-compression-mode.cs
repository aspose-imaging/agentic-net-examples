using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.dng";
            string outputPath = "C:\\temp\\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Configure JPEG2000 options for lossless compression and metadata preservation
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    Irreversible = false,   // Use lossless DWT 5-3
                    KeepMetadata = true     // Preserve original metadata
                };

                // Save the image as JPEG2000
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
 * 1. When a photographer needs to archive raw DNG captures in a lossless JPEG2000 format while keeping EXIF and XMP metadata for long‑term storage.
 * 2. When a medical imaging application must convert DNG scans to JPEG2000 to meet DICOM compatibility without sacrificing image fidelity or losing patient metadata.
 * 3. When a digital asset management system processes incoming raw DNG files and stores them as JPEG2000 to reduce file size while preserving original metadata for search and retrieval.
 * 4. When a web service generates high‑quality previews of raw DNG photos by converting them to lossless JPEG2000 for fast streaming and retaining all camera metadata.
 * 5. When a scientific research pipeline needs to transform raw DNG microscopy images into JPEG2000 for archival analysis, ensuring lossless compression and retention of experimental metadata.
 */