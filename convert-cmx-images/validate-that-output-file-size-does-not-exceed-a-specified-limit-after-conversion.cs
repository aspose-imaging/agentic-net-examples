using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

/// <summary>
/// Demonstrates loading an image, converting it, and validating the output file size.
/// </summary>
class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Maximum allowed output size in bytes (example: 5 MB)
        const long maxOutputSizeBytes = 5 * 1024 * 1024;

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (no special load options required)
            using (Image image = Image.Load(inputPath, new LoadOptions()))
            {
                // Define save options – here we convert to PNG
                var saveOptions = new PngOptions();

                // Save the converted image to the output path
                image.Save(outputPath, saveOptions);
            }

            // Validate the size of the generated file
            long outputSize = new FileInfo(outputPath).Length;
            if (outputSize > maxOutputSizeBytes)
            {
                Console.Error.WriteLine($"Output file size {outputSize} exceeds limit of {maxOutputSizeBytes} bytes.");
            }
            else
            {
                Console.WriteLine($"Conversion succeeded. Output size: {outputSize} bytes.");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application must convert user‑uploaded JPEG photos to PNG thumbnails and ensure each generated file stays under a 5 MB upload limit.
 * 2. When an automated batch‑processing service converts high‑resolution scans to lossless PNG for archival storage while guaranteeing the resulting files do not exceed a predefined storage quota.
 * 3. When a desktop utility resizes and converts images for email attachments and needs to verify that the final PNG size complies with the email provider’s attachment size restriction.
 * 4. When a cloud‑based document generation pipeline transforms embedded images to PNG and must reject any output that would cause the final PDF to surpass a maximum file‑size threshold.
 * 5. When a mobile app synchronizes images to a server, converting them to PNG on the device and checking that each file remains within the network‑transfer limit to avoid throttling.
 */