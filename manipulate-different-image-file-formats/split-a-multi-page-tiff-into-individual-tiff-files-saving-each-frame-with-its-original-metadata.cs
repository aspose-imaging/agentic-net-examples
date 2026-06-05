using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directory paths
            string inputPath = "input.tif";
            string outputDir = "output_frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Copy the current frame to preserve its data and metadata
                    TiffFrame copiedFrame = TiffFrame.CopyFrame(tiffImage.Frames[i]);

                    // Create a new single‑frame TIFF image
                    using (TiffImage singleFrameTiff = new TiffImage(copiedFrame))
                    {
                        // Build output file path for this frame
                        string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");

                        // Ensure the directory for this file exists (unconditional call as required)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF
                        singleFrameTiff.Save(outputPath);
                    }
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
 * 1. When a medical imaging system receives a multi‑page DICOM‑converted TIFF scan and must store each slice as a separate TIFF file while preserving patient metadata for downstream analysis.
 * 2. When a document management workflow needs to extract individual scanned pages from a multi‑page TIFF archive to index each page separately in a search engine, keeping the original EXIF and TIFF tags intact.
 * 3. When a GIS application processes a multi‑band satellite TIFF and wants to save each band as its own single‑frame TIFF for independent rendering, retaining geospatial metadata.
 * 4. When an e‑commerce platform receives bulk product catalog images packaged as a multi‑page TIFF and must generate separate TIFF files for each product image while preserving color profile information.
 * 5. When an archival system migrates historical newspaper microfilm stored as multi‑page TIFFs and requires each page to be saved as an individual TIFF with original metadata for compliance and retrieval.
 */