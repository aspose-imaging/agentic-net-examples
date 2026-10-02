// HOW-TO: Batch Convert BMP Images to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            // Hardcoded source and destination folders
            string sourceFolder = @"C:\Images\Source";
            string destinationFolder = @"C:\Images\Output";

            // Get all BMP files in the source folder
            string[] bmpFiles = Directory.GetFiles(sourceFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare output path with .png extension, preserving filename
                    string outputPath = Path.Combine(
                        destinationFolder,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When you need to migrate a legacy collection of BMP files to the more web‑friendly PNG format while keeping the original file names.
 * 2. When an automated build process must generate PNG assets from BMP sources for faster page load times in a web application.
 * 3. When a desktop utility has to process dozens of user‑uploaded BMP screenshots and store them as lossless PNGs for archival.
 * 4. When a server‑side service converts incoming BMP images to PNG before feeding them into a machine‑learning pipeline that only accepts PNG.
 * 5. When a batch job prepares image assets for a mobile app by converting BMP icons to PNG while preserving naming conventions.
 */
