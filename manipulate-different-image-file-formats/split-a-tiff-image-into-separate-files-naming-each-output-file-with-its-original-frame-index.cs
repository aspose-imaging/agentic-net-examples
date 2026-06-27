using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Create a new TiffImage containing only the current frame
                    using (TiffImage singleFrameImage = new TiffImage(tiffImage.Frames[i]))
                    {
                        // Build output file path using the original frame index
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                        // Ensure the directory for the output file exists (unconditional as required)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF
                        singleFrameImage.Save(outputPath);
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
 * 1. When a medical imaging system receives a multi‑frame DICOM‑converted TIFF scan and needs to store each slice as an individual file for separate analysis.
 * 2. When a document management workflow must extract each page of a scanned multi‑page TIFF contract into separate TIFF files to apply page‑level OCR or digital signatures.
 * 3. When a GIS application processes a multi‑band satellite TIFF and wants to isolate each band as its own single‑frame TIFF for independent raster calculations.
 * 4. When a printing service prepares a multi‑page TIFF brochure and must generate individual TIFF files to send to different printers or print queues.
 * 5. When a software tester automates validation of animation frames stored in a multi‑frame TIFF and requires each frame saved separately to compare against expected images.
 */