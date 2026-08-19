// HOW-TO: Convert JPEG to PNG and Verify Output Size Limit in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Maximum allowed output file size (e.g., 5 MB)
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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Define save options (PNG in this example)
                var saveOptions = new PngOptions();

                // Save the image to the output path
                image.Save(outputPath, saveOptions);
            }

            // Check the size of the generated file
            FileInfo outInfo = new FileInfo(outputPath);
            if (outInfo.Length > maxOutputSizeBytes)
            {
                Console.Error.WriteLine(
                    $"Output file size {outInfo.Length} bytes exceeds the limit of {maxOutputSizeBytes} bytes.");
            }
            else
            {
                Console.WriteLine(
                    $"Conversion succeeded. Output file size: {outInfo.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert user‑uploaded JPEG photos to PNG for web delivery while ensuring the resulting file stays under a bandwidth‑friendly size limit.
 * 2. When an automated batch process must generate thumbnails in PNG format and reject any image that exceeds a predefined maximum file size.
 * 3. When a cloud service stores images in a storage tier that caps file size, you can convert and validate each image before upload.
 * 4. When regulatory compliance requires that exported images not surpass a specific byte size, this code checks the size immediately after saving.
 * 5. When integrating Aspose.Imaging into a C# application to re‑encode images, you can also enforce a size constraint to avoid exceeding email attachment limits.
 */
