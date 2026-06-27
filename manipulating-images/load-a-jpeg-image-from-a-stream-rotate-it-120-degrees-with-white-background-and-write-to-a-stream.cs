using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image from a stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (JpegImage image = new JpegImage(inputStream))
            {
                // Rotate 120 degrees clockwise, resize proportionally, white background
                image.Rotate(120f, true, Aspose.Imaging.Color.White);

                // Save the rotated image to a stream
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    image.Save(outputStream, new JpegOptions());
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
 * 1. When a web service needs to accept a JPEG uploaded by a user, rotate it by 120 degrees with a white background, and return the transformed image directly from a stream.
 * 2. When a desktop application processes scanned photos stored in a stream, applies a 120‑degree clockwise rotation to correct orientation, and saves the result as a new JPEG file.
 * 3. When an automated batch job reads JPEG images from a network share via streams, rotates them for consistent layout in a catalog, and writes the rotated images to another stream.
 * 4. When a mobile backend receives JPEG data from an API, rotates the image to match UI design specifications, and streams the modified JPEG back to the client.
 * 5. When a document generation system needs to embed a rotated JPEG into a PDF, it loads the image from a stream, rotates it 120 degrees with a white fill, and streams the rotated JPEG for further processing.
 */