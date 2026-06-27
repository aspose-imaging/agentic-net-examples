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
            // Hard‑coded input and output paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.tif",
                @"C:\Images\input2.tif",
                @"C:\Images\input3.tif"
            };
            string outputPath = @"C:\Images\output.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image – it will become the base of the concatenated file
            using (TiffImage resultImage = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append frames from the remaining TIFF images
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage srcImage = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        // Add all frames (and their associated EXIF data) from srcImage to resultImage
                        resultImage.Add(srcImage);
                    }
                }

                // Save the combined multi‑page TIFF
                resultImage.Save(outputPath);
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
 * 1. When a medical imaging system needs to combine multiple DICOM‑exported TIFF scans into a single multi‑page TIFF archive while keeping each scan’s EXIF tags for patient and acquisition data.
 * 2. When a legal firm digitizes a multi‑page contract as separate TIFF pages and wants to merge them into one searchable file without losing the original metadata that records scan dates and operator information.
 * 3. When a publishing workflow assembles scanned book chapters stored as individual TIFF files into a single multi‑page TIFF for print‑ready proofing, preserving EXIF metadata for version control.
 * 4. When a GIS application consolidates aerial photograph tiles saved as TIFF images into a single file for archival, ensuring each tile’s geolocation EXIF data remains intact.
 * 5. When an archival system merges scanned historical documents, each saved as a separate TIFF with provenance metadata, into one multi‑page TIFF to maintain the original EXIF information for future reference.
 */