using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF file paths
            string inputPath1 = @"C:\Images\part1.tif";
            string inputPath2 = @"C:\Images\part2.tif";
            string inputPath3 = @"C:\Images\part3.tif";

            // Verify each input file exists
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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Load each TIFF as a frame
            TiffFrame frame1 = new TiffFrame(inputPath1);
            TiffFrame frame2 = new TiffFrame(inputPath2);
            TiffFrame frame3 = new TiffFrame(inputPath3);

            // Create a multi‑frame TIFF image from the loaded frames
            using (TiffImage multiFrameTiff = new TiffImage(new TiffFrame[] { frame1, frame2, frame3 }))
            {
                // Hardcoded output path
                string outputPath = @"C:\Images\combined.tif";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the combined TIFF
                multiFrameTiff.Save(outputPath);
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
 * 1. When a developer needs to merge scanned document pages stored as separate TIFF files into a single multi‑frame TIFF for easier archival and viewing.
 * 2. When an application must combine individual satellite image tiles saved as TIFFs into one multi‑page TIFF for batch analysis.
 * 3. When a medical imaging system has separate DICOM‑exported TIFF slices that must be concatenated into a single TIFF series for radiology review.
 * 4. When a printing workflow requires assembling separate high‑resolution TIFF graphics into one multi‑frame TIFF to send to a printer that only accepts multi‑page TIFFs.
 * 5. When a digital asset management tool needs to create a combined TIFF portfolio from individual artwork scans for quick preview and download.
 */