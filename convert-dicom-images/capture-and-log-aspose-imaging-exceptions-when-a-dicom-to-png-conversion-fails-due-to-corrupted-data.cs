using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image (may throw DicomImageException)
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
        // Capture specific DICOM conversion errors
        catch (DicomImageException ex)
        {
            Console.Error.WriteLine($"Dicom conversion error: {ex.Message}");
        }
        // Capture any other runtime errors
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application must convert patient DICOM scans to PNG thumbnails and needs to log conversion failures caused by corrupted DICOM files.
 * 2. When a hospital's PACS integration script processes batch DICOM files and must capture Aspose.Imaging DicomImageException to prevent the entire batch from stopping.
 * 3. When a cloud‑based image processing service receives DICOM uploads and wants to record detailed error messages if the data is incomplete or damaged during PNG conversion.
 * 4. When a diagnostic software tool validates incoming DICOM images before display and requires exception handling to alert users of unreadable files.
 * 5. When an automated ETL pipeline extracts DICOM images, converts them to PNG for analytics, and needs to log any runtime or format‑specific errors to a monitoring system.
 */