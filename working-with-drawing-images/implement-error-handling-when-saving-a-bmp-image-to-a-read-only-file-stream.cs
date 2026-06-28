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
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\readonly\output.bmp";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options (default options are sufficient for this demo)
                BmpOptions saveOptions = new BmpOptions();

                // Open a read‑only file stream to simulate a write‑protected destination
                // The stream is opened with FileAccess.Read, so any write attempt will fail
                using (FileStream readOnlyStream = new FileStream(outputPath, FileMode.Create, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        // Attempt to save the image to the read‑only stream
                        image.Save(readOnlyStream, saveOptions);
                        Console.WriteLine("Image saved successfully (unexpected).");
                    }
                    catch (ImageSaveException ex)
                    {
                        // Handle generic image saving failures
                        Console.Error.WriteLine($"ImageSaveException caught: {ex.Message}");
                    }
                    catch (BmpImageException ex)
                    {
                        // Handle BMP‑specific saving failures
                        Console.Error.WriteLine($"BmpImageException caught: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Fallback for any other exceptions during save
                        Console.Error.WriteLine($"Unexpected exception during save: {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When an application converts user‑uploaded BMP files and must verify that the target folder is not write‑protected before saving, this code catches the permission error.
 * 2. When a scheduled batch job processes images on a network share that may be set to read‑only, the error handling prevents the job from crashing and logs the failure.
 * 3. When a desktop utility needs to enforce security policies by attempting to write to a read‑only stream and gracefully reporting the inability to save the BMP image.
 * 4. When developers debug an image‑processing pipeline that writes BMP files to a temporary location that could be locked by another process, the try‑catch block reveals the exact ImageSaveException.
 * 5. When a cloud‑based service stores BMP outputs in a container with immutable storage settings, this pattern ensures the application detects and handles the write‑access violation.
 */