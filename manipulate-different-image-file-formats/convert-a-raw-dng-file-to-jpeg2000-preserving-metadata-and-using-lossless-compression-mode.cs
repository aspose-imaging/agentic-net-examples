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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.jp2";

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

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access RAW-specific features
                DngImage dngImage = (DngImage)image;

                // Prepare JPEG2000 save options for lossless compression and metadata preservation
                Jpeg2000Options saveOptions = new Jpeg2000Options
                {
                    // Irreversible = false (default) => lossless DWT 5-3 compression
                    Irreversible = false,
                    // Keep original metadata when exporting
                    KeepMetadata = true
                };

                // Save as JPEG2000
                dngImage.Save(outputPath, saveOptions);
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
 * 1. When a photography workflow requires converting raw DNG files captured by a DSLR into lossless JPEG2000 for archival storage while preserving EXIF metadata.
 * 2. When a medical imaging application needs to ingest raw sensor data in DNG format and export it as JPEG2000 to meet DICOM compatibility without losing image fidelity.
 * 3. When a digital publishing platform wants to generate high‑quality, metadata‑rich JPEG2000 assets from raw camera files for use in print‑ready PDFs.
 * 4. When a cloud‑based image processing service must batch‑convert client‑uploaded DNG images to lossless JPEG2000 to reduce file size while keeping all original metadata for downstream analytics.
 * 5. When a scientific research project needs to transform raw microscope captures stored as DNG into JPEG2000 for lossless compression and metadata retention before feeding them into image analysis pipelines.
 */