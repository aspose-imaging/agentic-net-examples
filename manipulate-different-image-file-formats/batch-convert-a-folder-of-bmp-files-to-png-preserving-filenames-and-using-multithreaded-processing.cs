using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            // Process files in parallel
            Parallel.ForEach(bmpFiles, bmpPath =>
            {
                // Verify the input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Build the output PNG path, preserving the filename
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(bmpPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    // Load the BMP image
                    using (Image image = Image.Load(bmpPath))
                    {
                        // Save as PNG using default options
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                }
                catch (Exception ex)
                {
                    // Report any error that occurs while processing this file
                    Console.Error.WriteLine($"Error processing '{bmpPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            // Report any unexpected error from the overall process
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate legacy BMP assets from a design folder to web‑friendly PNG files using Aspose.Imaging for .NET while preserving original filenames for a website launch.
 * 2. When an automated build pipeline must convert a large collection of scanned BMP screenshots into lossless PNGs with Aspose.Imaging’s multithreaded processing to reduce storage size and improve loading speed.
 * 3. When a desktop application processes user‑uploaded BMP images in bulk and must output PNGs concurrently with Aspose.Imaging to keep the UI responsive.
 * 4. When a server‑side service prepares image bundles for mobile apps by transforming BMP icons to PNG format using Aspose.Imaging’s parallel processing to meet performance SLAs.
 * 5. When a data‑migration script needs to archive BMP files from an old archive folder into a new PNG repository with Aspose.Imaging, preserving directory structure and handling errors gracefully.
 */