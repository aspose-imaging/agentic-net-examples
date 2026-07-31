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

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame (page)
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];

                    // Calculate a simple duration based on the frame's resolution.
                    // Higher DPI → shorter display time (example logic).
                    double avgDpi = (frame.HorizontalResolution + frame.VerticalResolution) / 2.0;
                    int durationMs = (int)(1000 / Math.Max(avgDpi, 1)); // duration in milliseconds

                    // If you need to store the duration in the TIFF, you could add a custom tag here.
                    // Example (placeholder, actual tag name may differ):
                    // frame.Tags.Add(TiffTag.PageDelay, durationMs);
                }

                // Save the modified TIFF to the output path
                tiffImage.Save(outputPath);
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
 * 1. When creating a digital archive of scanned documents where each page’s display time should adapt to its scan resolution, a developer can load the multi‑page TIFF and set per‑frame durations accordingly.
 * 2. When building a medical imaging viewer that shows high‑resolution radiology slides for a shorter period than lower‑resolution ones, the code can calculate and embed frame delays based on DPI.
 * 3. When generating an animated TIFF slideshow from a set of photographs taken at different resolutions, the developer can use this logic to make sharper images appear faster.
 * 4. When developing a document‑to‑TIFF conversion tool that needs to preserve page‑turn speed proportional to image quality, the snippet provides a way to read each frame’s resolution and assign a custom tag for delay.
 * 5. When implementing a quality‑control dashboard that highlights low‑resolution scans longer for review, the code can load the TIFF, compute average DPI per page, and adjust the display interval accordingly.
 */