// HOW-TO: Apply Horizontal Motion Wiener Filter to PNG Video Frame in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\video_frame.png";
        string outputPath = @"C:\Images\video_frame_motion_wiener.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply MotionWiener filter with horizontal motion (angle = 0 degrees)
                // Size = 10, Sigma = 1.0 (adjust as needed)
                var options = new MotionWienerFilterOptions(10, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, options);

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When you need to reduce motion blur in a single video frame saved as a PNG before further analysis.
 * 2. When you want to enhance the sharpness of horizontally moving objects in surveillance footage stored as PNG images.
 * 3. When preparing PNG screenshots from a video for machine‑learning preprocessing that requires de‑blurring.
 * 4. When cleaning up PNG frames extracted from a dash‑cam video to improve visual quality for reporting.
 * 5. When automating a batch process that applies a motion‑compensated Wiener filter to PNG images captured from any video source.
 */
