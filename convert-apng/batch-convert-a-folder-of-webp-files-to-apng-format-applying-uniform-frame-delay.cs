using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputWebp";
            string outputFolder = @"C:\OutputApng";

            // Uniform frame delay in milliseconds
            uint frameDelay = 200;

            // Get all .webp files in the input folder
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with the specified default frame time
                    image.Save(outputPath, new ApngOptions() { DefaultFrameTime = frameDelay });
                }
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
 * 1. When a developer needs to convert a collection of animated WebP assets from a design folder into APNG files for use in web browsers that support PNG animation, applying a consistent frame delay.
 * 2. When an e‑learning platform must transform uploaded WebP lesson illustrations into APNG format so that all frames display at the same speed across different devices.
 * 3. When a game studio automates the migration of sprite animations stored as WebP into APNG to integrate with a Unity UI system that expects PNG sequences with uniform timing.
 * 4. When a marketing team requires a script to batch process promotional WebP animations into APNG for email newsletters, ensuring each frame shows for a fixed number of milliseconds.
 * 5. When a content management system needs to generate APNG thumbnails from a folder of WebP files, using a standard frame delay to maintain consistent animation playback.
 */