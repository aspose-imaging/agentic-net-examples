// HOW-TO: Rotate JPEG Image 120 Degrees with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
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

            // Load JPEG image from a file stream
            using (Stream inputStream = File.OpenRead(inputPath))
            using (JpegImage jpegImage = new JpegImage(inputStream))
            {
                // Rotate 120 degrees, resize canvas, fill background with white
                jpegImage.Rotate(120f, true, Aspose.Imaging.Color.White);

                // Save the rotated image to an output stream with default JPEG options
                using (Stream outputStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
                {
                    jpegImage.Save(outputStream, new JpegOptions());
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
 * 1. When you need to programmatically rotate a user‑uploaded JPEG by a specific angle while filling the empty canvas area with a white background for consistent web display.
 * 2. When processing scanned photos that were captured upside‑down and must be corrected to a 120° orientation before archiving them as JPEG files.
 * 3. When generating thumbnails for a mobile app that require a uniform orientation and a solid white background to avoid transparent edges.
 * 4. When integrating an image‑processing pipeline that reads JPEGs from a stream, applies a 120° rotation, and writes the result to another stream for downstream services.
 * 5. When automating batch preparation of JPEG images for printing, ensuring each picture is rotated and padded with white space to meet layout specifications.
 */
