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
            // Hardcoded input TIFF file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.tif",
                @"C:\Images\input2.tif",
                @"C:\Images\input3.tif"
            };

            // Hardcoded output TIFF file path
            string outputPath = @"C:\Images\output_combined.tif";

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

            // Load the first TIFF as the base image
            using (TiffImage result = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append frames from remaining TIFF files
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage src = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        result.Add(src); // Preserves each frame's EXIF metadata
                    }
                }

                // Save the combined multi‑page TIFF
                result.Save(outputPath);
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
 * 1. When a medical imaging system must merge separate DICOM‑exported TIFF scans into a single multi‑page TIFF while keeping each frame’s original EXIF tags for regulatory compliance.
 * 2. When a digital archiving workflow needs to combine scanned historical documents stored as individual TIFF files into one searchable archive file without losing the capture date and camera settings stored in EXIF metadata.
 * 3. When a publishing platform assembles multiple high‑resolution TIFF illustrations into a single multi‑page TIFF for print proofs, preserving each illustration’s color profile and metadata for consistent reproduction.
 * 4. When a construction project management tool consolidates site‑photography TIFF images taken at different times into one file, retaining GPS coordinates and timestamps in EXIF for later geospatial analysis.
 * 5. When a legal e‑discovery process concatenates TIFF evidence pages while maintaining each page’s original metadata to ensure chain‑of‑custody integrity in court filings.
 */