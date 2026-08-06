using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            try
            {
                // Load DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as PNG
                    image.Save(outputPath, new PngOptions());
                }
            }
            catch (DicomImageException dex)
            {
                // Log Aspose.Imaging DICOM-specific errors (e.g., corrupted data)
                Console.Error.WriteLine($"Dicom conversion error: {dex.Message}");
            }
            catch (ImageSaveException isex)
            {
                // Log errors that occur during saving
                Console.Error.WriteLine($"Image save error: {isex.Message}");
            }
            catch (PngImageException pex)
            {
                // Log PNG-specific errors
                Console.Error.WriteLine($"PNG conversion error: {pex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Catch any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital’s PACS system automatically converts incoming DICOM scans to PNG thumbnails for a web portal and needs to capture and log conversion failures caused by corrupted DICOM data.
 * 2. When a research lab processes large batches of medical images and wants to record any DicomImageException that occurs during batch conversion to PNG so the problematic files can be reviewed later.
 * 3. When a telemedicine application receives patient‑uploaded DICOM files and must safely attempt to save them as PNG while logging detailed Aspose.Imaging errors if the file is incomplete or damaged.
 * 4. When an imaging middleware service integrates Aspose.Imaging to transform DICOM images into PNG for downstream AI analysis and needs to log ImageSaveException or PngImageException when the save step fails.
 * 5. When a desktop utility converts DICOM files to PNG for clinicians and must provide clear error messages in the console for any unexpected exceptions, ensuring corrupted data does not crash the application.
 */