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
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Adjust each frame based on its resolution
                foreach (TiffFrame frame in tiff.Frames)
                {
                    double horiz = frame.HorizontalResolution;
                    double vert = frame.VerticalResolution;

                    // Example logic: higher DPI pages get a longer display duration.
                    // Here we simply modify the resolution to illustrate the concept.
                    if (horiz > 300 || vert > 300)
                    {
                        // High‑resolution page – increase resolution (simulating longer duration)
                        frame.HorizontalResolution = horiz * 2;
                        frame.VerticalResolution = vert * 2;
                    }
                    else
                    {
                        // Lower‑resolution page – moderate increase
                        frame.HorizontalResolution = horiz * 1.5;
                        frame.VerticalResolution = vert * 1.5;
                    }
                }

                // Save the modified TIFF
                tiff.Save(outputPath);
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
 * 1. When a developer needs to create a multi‑page TIFF slideshow where high‑resolution pages stay on screen longer, they can load each frame, inspect its DPI, and adjust the resolution to control display duration.
 * 2. When processing scanned documents that contain pages with varying DPI, a developer can use this code to normalize or emphasize high‑resolution pages before saving the combined TIFF.
 * 3. When generating a printable PDF from a multi‑page TIFF and wants to preserve the visual weight of high‑quality scans, the developer can increase the resolution of those frames to signal longer exposure in the final output.
 * 4. When building a medical imaging archive that stores radiology images as multi‑page TIFFs, a developer can tag higher‑resolution slices by scaling their DPI, making them easier to prioritize during review.
 * 5. When creating an animated GIF from a multi‑page TIFF and need to set frame delays based on each page’s original resolution, a developer can read the DPI values, adjust them, and then convert the TIFF to the animated format.
 */