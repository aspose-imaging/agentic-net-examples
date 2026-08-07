using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.jpg";

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

            // Convert CDR to JPG with its own error handling
            try
            {
                // Load the CDR image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG save options (default quality)
                    JpegOptions jpegOptions = new JpegOptions();

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Conversion successful: {outputPath}");
            }
            catch (Exception convEx)
            {
                // Log conversion-specific exceptions
                Console.Error.WriteLine($"Conversion error: {convEx.Message}");
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET application must generate JPEG previews of CorelDRAW (CDR) files for a web gallery and needs robust error handling to log missing files or conversion failures.
 * 2. When an automated document processing pipeline converts user‑uploaded CDR designs to JPG thumbnails and must catch and record runtime exceptions to prevent pipeline crashes.
 * 3. When a desktop utility processes a batch of CDR assets stored on a network share, converting each to JPEG while ensuring that file‑system errors and Aspose.Imaging conversion issues are logged for later review.
 * 4. When a cloud‑based microservice receives CDR images via API, transforms them to JPEG for downstream consumption, and requires try‑catch blocks to capture and log any unexpected .NET or Aspose.Imaging errors.
 * 5. When integrating Aspose.Imaging into a Windows service that monitors a folder for new CDR files, converts them to JPG, and needs comprehensive exception handling to diagnose permission or format‑specific problems.
 */