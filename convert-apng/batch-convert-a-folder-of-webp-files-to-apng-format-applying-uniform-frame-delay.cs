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

            // Get all WEBP files in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.webp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WEBP image and save as APNG with a uniform frame delay
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions
                    {
                        // Frame delay in milliseconds (e.g., 200 ms)
                        DefaultFrameTime = 200
                    };
                    image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to automate the conversion of a large collection of animated WEBP files into APNG format for web deployment, applying a consistent frame delay across all animations.
 * 2. When a game studio wants to replace legacy WEBP sprite animations with APNG assets in a Unity project, using C# and Aspose.Imaging to process the entire assets folder in one run.
 * 3. When an e‑learning platform must generate uniformly timed APNG tutorials from user‑uploaded WEBP animations before publishing them to a learning management system.
 * 4. When a digital marketing team requires a script to batch convert promotional WEBP banners into APNGs with a fixed 200 ms frame interval for consistent playback on email newsletters.
 * 5. When a content management system needs to migrate archived WEBP animated images to APNG while ensuring each frame displays for the same duration, using a C# batch process with Aspose.Imaging.
 */