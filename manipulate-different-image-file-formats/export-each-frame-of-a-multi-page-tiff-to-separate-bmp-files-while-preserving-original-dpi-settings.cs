using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output locations
            string inputPath = @"C:\Images\multi.tif";
            string outputDirectory = @"C:\Images\Frames";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame in the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];

                    // Build the output BMP file path
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as BMP while preserving DPI
                    BmpOptions bmpOptions = new BmpOptions();
                    // DPI values are taken from the source frame automatically
                    frame.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging system receives multi‑page TIFF scans of pathology slides and needs to generate individual high‑resolution BMP files for each slide while keeping the original DPI for accurate measurements.
 * 2. When a document management workflow must convert multi‑page TIFF invoices into separate BMP images for OCR processing, preserving DPI to maintain text clarity.
 * 3. When a GIS application stores satellite imagery as multi‑page TIFF and requires extracting each band as a BMP file with the same DPI for precise georeferencing.
 * 4. When a printing service receives multi‑page TIFF proofs and wants to split them into individual BMP files for per‑page color calibration, ensuring the DPI settings remain unchanged.
 * 5. When an archival tool needs to backup each page of a scanned multi‑page TIFF book as separate BMP files for long‑term storage, retaining the original DPI to preserve image quality.
 */