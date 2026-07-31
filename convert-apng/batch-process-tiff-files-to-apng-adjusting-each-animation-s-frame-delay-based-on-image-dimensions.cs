using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputTiffs";
            string outputFolder = @"C:\OutputApngs";

            // Ensure the output folder exists (creates the root folder)
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image (may contain multiple frames)
                using (Image tiffImage = Image.Load(inputPath))
                {
                    // Determine a frame delay based on image dimensions.
                    // Example: average of width and height in milliseconds.
                    uint frameDelay = (uint)((tiffImage.Width + tiffImage.Height) / 2);

                    // Prepare APNG save options with the calculated default frame time
                    ApngOptions apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = frameDelay
                    };

                    // Build the output file path (same name with .png extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as APNG using the specified options
                    tiffImage.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to batch convert multi‑page TIFF files into animated PNG (APNG) files while automatically setting each frame’s delay based on the image’s width and height.
 * 2. When an imaging pipeline must generate web‑ready APNG animations from scanned TIFF documents, using Aspose.Imaging for .NET to calculate frame timing from image dimensions.
 * 3. When a C# application has to process large sets of satellite or medical TIFF images into APNG sequences, ensuring the animation speed adapts to the resolution of each frame.
 * 4. When a software tool needs to automate the migration of legacy TIFF assets to APNG format for mobile apps, with dynamic frame delays derived from the image size to maintain visual consistency.
 * 5. When a developer wants to create a scheduled job that reads TIFF files from a folder, converts them to APNG, and saves them with appropriate default frame times without manually specifying each delay.
 */