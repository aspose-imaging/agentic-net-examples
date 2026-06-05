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
            // Hard‑coded input TIFF files (adjust paths as needed)
            string[] inputPaths = new[]
            {
                @"C:\Images\part1.tif",
                @"C:\Images\part2.tif",
                @"C:\Images\part3.tif"
            };

            // Hard‑coded output file
            string outputPath = @"C:\Images\combined.tif";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image – this will become the destination image
            using (TiffImage combinedImage = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append remaining TIFF images frame‑by‑frame
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage nextImage = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        // Add all frames (including their EXIF metadata) from nextImage
                        combinedImage.Add(nextImage);
                    }
                }

                // Save the concatenated multi‑page TIFF
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
 * 1. When a medical imaging system needs to combine multiple DICOM‑exported TIFF scans into a single multi‑page TIFF for patient records while keeping each scan’s EXIF metadata intact.
 * 2. When a legal firm archives scanned contract pages as a single TIFF file but must retain the original capture dates and camera settings stored in EXIF for evidentiary purposes.
 * 3. When a publishing workflow merges separate high‑resolution TIFF illustrations into one document for print production, ensuring the color profile and resolution metadata are preserved.
 * 4. When a construction company consolidates daily site‑photo TIFFs into a chronological multi‑page archive, keeping GPS coordinates and timestamps from EXIF for project tracking.
 * 5. When a museum digitization project stitches individual TIFF scans of artwork panels into a single file for cataloging, while maintaining each panel’s provenance metadata embedded in EXIF.
 */