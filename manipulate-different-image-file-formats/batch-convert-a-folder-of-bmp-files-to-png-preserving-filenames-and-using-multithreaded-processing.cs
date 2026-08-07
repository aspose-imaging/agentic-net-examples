using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputBmp";
        string outputFolder = @"C:\OutputPng";

        try
        {
            // Get all BMP files in the input folder (non-recursive)
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            // Process files in parallel
            Parallel.ForEach(bmpFiles, bmpPath =>
            {
                // Verify input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Determine output file path with .png extension
                string fileName = Path.GetFileNameWithoutExtension(bmpPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(bmpPath))
                {
                    // Set PNG save options (default)
                    PngOptions pngOptions = new PngOptions();

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate a legacy collection of BMP assets to PNG for web delivery while preserving original filenames, using C# and Aspose.Imaging with multithreaded batch conversion.
 * 2. When an automated build pipeline must convert scanned BMP documents into lossless PNG files to reduce storage size and improve compatibility across browsers, leveraging Parallel.ForEach for faster processing.
 * 3. When a desktop application has to generate PNG thumbnails from a folder of BMP images on the fly, ensuring the output folder structure is created automatically and the conversion runs concurrently.
 * 4. When a server‑side service processes user‑uploaded BMP pictures and stores them as PNG in a separate directory, using Aspose.Imaging’s Image.Load and PngOptions to maintain image quality while handling many files in parallel.
 * 5. When a migration script needs to batch convert BMP graphics from an old Windows application to PNG for a cross‑platform .NET project, employing C# file I/O and Aspose.Imaging’s multithreaded processing to speed up the task.
 */