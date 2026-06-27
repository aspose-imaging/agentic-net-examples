using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input TIFF files (replace with actual paths as needed)
            string[] inputPaths = new[]
            {
                @"C:\Images\input1.tif",
                @"C:\Images\input2.tif",
                @"C:\Images\input3.tif"
            };

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Hard‑coded output path
            string outputPath = @"C:\Images\output_combined.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image to serve as the base container
            using (TiffImage combinedImage = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append frames from the remaining TIFF images
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage nextImage = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        combinedImage.Add(nextImage); // Preserves each frame's original compression
                    }
                }

                // Save the combined multi‑page TIFF
                combinedImage.Save(outputPath);
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
 * 1. When a developer needs to merge scanned document pages stored as separate multi‑page TIFF files into a single archival TIFF while keeping each page’s original LZW or CCITT compression.
 * 2. When a medical imaging system must combine individual DICOM‑derived TIFF slices into one multi‑frame TIFF for long‑term storage without re‑encoding the lossless compression.
 * 3. When a legal firm wants to concatenate multiple case‑file TIFFs into a single searchable bundle while preserving the original G4 fax compression for compliance.
 * 4. When a GIS application aggregates raster map tiles saved as TIFFs into a single multi‑page TIFF for offline archiving, ensuring each tile’s original Deflate compression remains unchanged.
 * 5. When a publishing workflow combines separate high‑resolution TIFF artwork layers into a single multi‑page TIFF for archival printing, retaining each layer’s original compression to minimize file size.
 */