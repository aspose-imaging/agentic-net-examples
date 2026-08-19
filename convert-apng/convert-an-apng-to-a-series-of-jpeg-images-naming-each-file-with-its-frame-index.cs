// HOW-TO: Extract APNG Frames to Indexed JPEG Files Using C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames (pages)
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded image is not an APNG.");
                    return;
                }

                // Iterate through each frame and save as JPEG
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Get the frame (page)
                    var frame = apng.Pages[i];

                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.jpg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as JPEG
                    frame.Save(outputPath, new JpegOptions());
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
 * 1. When you need to break an animated PNG into individual JPEG images for use in a web gallery that only supports static JPEG thumbnails.
 * 2. When a game developer wants to convert each frame of an APNG sprite sheet into separate JPEG assets for faster loading on low‑memory devices.
 * 3. When a reporting tool must embed each animation frame as a JPEG in a PDF document that does not support APNG.
 * 4. When a batch‑processing pipeline extracts frames from user‑uploaded APNG files to generate indexed JPEG files for archival storage.
 * 5. When a mobile app requires frame‑by‑frame JPEG images from an APNG to apply custom filters or overlays in C#.
 */
