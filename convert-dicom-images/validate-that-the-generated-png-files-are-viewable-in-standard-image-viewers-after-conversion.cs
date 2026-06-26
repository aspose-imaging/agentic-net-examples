using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call)
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load the source image (any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options (default options are sufficient)
                PngOptions pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }

            // Validate that the saved PNG can be loaded (viewable in standard viewers)
            if (Image.CanLoad(outputPath))
            {
                Console.WriteLine("PNG saved successfully and is viewable.");
            }
            else
            {
                Console.Error.WriteLine("Saved PNG could not be loaded; it may be corrupted.");
            }
        }
        catch (Exception ex)
        {
            // Catch any runtime exception and report it
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert user‑uploaded JPEG photos to PNG for lossless web delivery and verify that the resulting files open in standard image viewers.
 * 2. When an automated batch job must normalize mixed‑format image assets to PNG before indexing them in a searchable media library, confirming each conversion succeeded.
 * 3. When a desktop application processes scanned JPEG documents, saves them as PNG for archival quality, and validates the output to prevent corrupted files from being stored.
 * 4. When a CI/CD pipeline includes a step that transforms generated JPEG screenshots into PNG for consistent rendering across platforms, checking that the PNG can be reloaded without errors.
 * 5. When a cloud service receives JPEG attachments, converts them to PNG for downstream processing (e.g., OCR or thumbnail generation), and uses Image.CanLoad to ensure the conversion produced a viewable image.
 */