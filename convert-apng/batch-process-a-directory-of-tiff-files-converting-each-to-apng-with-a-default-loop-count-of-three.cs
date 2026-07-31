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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with 3 loops
                    var apngOptions = new ApngOptions
                    {
                        NumPlays = 3 // default loop count
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
 * 1. When a developer needs to convert a large collection of scanned TIFF documents into animated PNGs for web galleries that require a three‑loop animation, they can use this batch‑processing code.
 * 2. When an e‑learning platform must transform multi‑page TIFF lesson slides into looping APNG assets for interactive tutorials, the script automates the conversion across a folder.
 * 3. When a medical imaging system stores radiology scans as TIFF files and wants to generate lightweight, three‑loop APNG previews for quick review in a browser, this code provides the necessary conversion.
 * 4. When a digital archivist wants to create animated PNG thumbnails that loop three times from a directory of high‑resolution TIFF photographs for a searchable online catalog, the program handles the batch conversion.
 * 5. When a marketing team needs to repurpose multi‑frame TIFF advertisements into looping APNG banners that play three cycles on a website, developers can employ this C# routine to process all files automatically.
 */