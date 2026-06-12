using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Global exception handling
        try
        {
            // Conversion-specific exception handling
            try
            {
                // Load the CDR file
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options (e.g., quality)
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (ImageSaveException ex)
            {
                Console.Error.WriteLine($"Image save error: {ex.Message}");
            }
            catch (ImageException ex)
            {
                Console.Error.WriteLine($"Image processing error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Conversion error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to batch‑convert CorelDRAW (.cdr) files to JPEG for web publishing while handling missing files and save errors.
 * 2. When an automated build pipeline processes design assets and must safely convert CDR graphics to JPG thumbnails, logging any image processing exceptions.
 * 3. When a cloud‑based service receives user‑uploaded CDR files and must generate JPEG previews without crashing, using try‑catch to capture ImageException and I/O issues.
 * 4. When a Windows service monitors a folder for new CDR files and converts them to high‑quality JPEGs, ensuring directory creation and error reporting through nested exception handling.
 * 5. When a legacy migration tool extracts vector artwork from CorelDRAW files and saves them as JPEGs for compatibility with mobile apps, requiring robust exception handling to log conversion failures.
 */