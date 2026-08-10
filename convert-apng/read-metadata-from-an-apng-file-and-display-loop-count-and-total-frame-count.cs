// HOW-TO: Read Loop Count and Frame Count from APNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "sample.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access APNG-specific properties
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The file is not a valid APNG image.");
                    return;
                }

                // Retrieve loop count and total frame count
                int loopCount = apng.NumPlays;      // Number of times the animation loops (0 = infinite)
                int frameCount = apng.PageCount;   // Total number of frames in the APNG

                // Display the metadata
                Console.WriteLine($"Loop count (NumPlays): {loopCount}");
                Console.WriteLine($"Total frame count (PageCount): {frameCount}");
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
 * 1. When you need to determine how many times an APNG animation will repeat and how many frames it contains before processing or displaying it.
 * 2. When building a media library that catalogs animated PNGs and you must store their loop count and frame count as searchable metadata.
 * 3. When validating user‑uploaded APNG files to ensure they meet specific animation length requirements for a web application.
 * 4. When generating reports on animation assets and need to extract APNG playback information programmatically in a C# backend.
 * 5. When converting or resizing APNG files and want to preserve or adjust the original number of loops and frames based on the source metadata.
 */
