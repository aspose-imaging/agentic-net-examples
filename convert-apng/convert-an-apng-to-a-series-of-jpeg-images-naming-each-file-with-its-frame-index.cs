using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded image is not an APNG.");
                    return;
                }

                // Iterate through each frame (page) and save as JPEG
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Get the current frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        // Construct output file name with frame index
                        string outputPath = $"frame_{i}.jpg";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        // Save the frame as JPEG
                        frame.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to extract each frame from an animated PNG (APNG) and store them as separate JPEG files for compatibility with browsers that only support static JPEG images.
 * 2. When a video processing pipeline requires converting an APNG sprite sheet into individual JPEG frames to create a thumbnail gallery.
 * 3. When an e‑learning platform wants to break down an animated illustration into frame‑by‑frame JPEG images for step‑by‑step instructional content.
 * 4. When a content management system must archive each animation frame as a lossily compressed JPEG to reduce storage size while preserving frame order.
 * 5. When a game developer wants to import APNG character animations into a Unity project by saving each frame as a JPEG asset with an indexed filename.
 */