// HOW-TO: Combine Multiple TIFF Files Preserving Original Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath1 = @"c:\temp\input1.tif";
        string inputPath2 = @"c:\temp\input2.tif";
        string outputPath = @"c:\temp\output.tif";

        try
        {
            // Verify that each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image – this will become the combined image
            using (TiffImage combined = (TiffImage)Image.Load(inputPath1))
            {
                // Load the second TIFF image
                using (TiffImage second = (TiffImage)Image.Load(inputPath2))
                {
                    // Append all frames from the second image to the combined image.
                    // The original compression of each frame is preserved.
                    combined.Add(second);
                }

                // Save the concatenated TIFF image
                combined.Save(outputPath);
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
 * 1. When you need to merge scanned document pages saved as separate TIFF files into a single multi‑page TIFF for archival while keeping each page’s original LZW or CCITT compression.
 * 2. When a medical imaging system produces individual TIFF slices and you must concatenate them into one file without re‑encoding to maintain lossless quality.
 * 3. When a digital preservation workflow requires combining TIFF images from different sources into a single archive file while preserving each frame’s original compression for authenticity.
 * 4. When an automated batch process has to append new TIFF pages to an existing multi‑page TIFF without recompressing the existing frames.
 * 5. When a GIS application stores raster layers as separate TIFF tiles and you need to stitch them into a single TIFF while retaining each tile’s compression for efficient storage.
 */
