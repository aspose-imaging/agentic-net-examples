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
            string inputPath = "input.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access APNG-specific metadata
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.WriteLine("The specified file is not an APNG image.");
                    return;
                }

                // Retrieve loop count (NumPlays) and total frame count (PageCount)
                int loopCount = apng.NumPlays; // 0 indicates infinite looping
                int frameCount = apng.PageCount;

                // Display the metadata
                Console.WriteLine($"Loop count (NumPlays): {(loopCount == 0 ? "Infinite" : loopCount.ToString())}");
                Console.WriteLine($"Total frame count: {frameCount}");
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
 * 1. When a game developer needs to verify that an animated PNG (APNG) asset loops the correct number of times before integrating it into a Unity UI, they can use this code to read the NumPlays and PageCount metadata.
 * 2. When a web application builds a dynamic image gallery and must display the total number of frames and whether an APNG will repeat infinitely, the snippet shows how to extract those values with Aspose.Imaging for .NET.
 * 3. When a content‑management system imports user‑submitted APNG files and must enforce a policy that animated images contain no more than a certain frame count, developers can read the PageCount using this C# example.
 * 4. When a digital‑signage solution schedules animated PNG advertisements and needs to calculate playback duration based on loop count and frame count, the code demonstrates how to obtain NumPlays and PageCount from the file.
 * 5. When a QA engineer automates testing of animated assets and wants to confirm that an APNG’s loop setting matches the specification (e.g., infinite looping), this C# routine provides a quick way to read the NumPlays metadata.
 */