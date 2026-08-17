// HOW-TO: Handle ImageSaveException When Saving BMP to Read‑Only Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\readonly_output.bmp";

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

            // Create an empty file and mark it as read‑only to simulate a read‑only stream scenario
            using (FileStream temp = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                // No content needed; just create the file
            }
            File.SetAttributes(outputPath, FileAttributes.ReadOnly);

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Open the output file as a read‑only stream (FileAccess.Read)
                using (FileStream readOnlyStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        // Attempt to save the image to the read‑only stream
                        image.Save(readOnlyStream);
                    }
                    catch (ImageSaveException ex)
                    {
                        // Specific handling for image save failures
                        Console.Error.WriteLine($"ImageSaveException: {ex.Message}");
                    }
                    catch (BmpImageException ex)
                    {
                        // Specific handling for BMP format errors
                        Console.Error.WriteLine($"BmpImageException: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // General fallback for any other errors during save
                        Console.Error.WriteLine($"Unexpected error while saving: {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling for any unexpected exceptions
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically save a BMP image but the destination file is marked read‑only, and you want to catch the failure gracefully.
 * 2. When processing batch image conversions and some output files have read‑only attributes, requiring error handling to avoid application crashes.
 * 3. When integrating Aspose.Imaging into a document management system that enforces read‑only permissions on stored images.
 * 4. When validating that your C# code correctly reports permission‑related errors during image export operations.
 * 5. When developing a backup utility that attempts to overwrite existing read‑only BMP files and must log specific ImageSaveException details.
 */
