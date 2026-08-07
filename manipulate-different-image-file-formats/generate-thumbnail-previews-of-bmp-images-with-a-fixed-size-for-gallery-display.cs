using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directories for input BMP files and output thumbnails
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure the input directory exists; create it if missing and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Retrieve all BMP files from the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            // Fixed thumbnail dimensions
            int thumbWidth = 150;
            int thumbHeight = 150;

            foreach (string inputPath in files)
            {
                // Verify the input file still exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct the output thumbnail path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{fileName}_thumb.bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image, resize to thumbnail size, and save
                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(thumbWidth, thumbHeight);
                    image.Save(outputPath, new BmpOptions());
                }

                Console.WriteLine($"Thumbnail saved: {outputPath}");
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
 * 1. When building a web photo gallery that needs fast‑loading preview images, a developer can use this C# code with Aspose.Imaging to generate fixed‑size BMP thumbnails for each original picture.
 * 2. When creating a desktop application that lets users browse large collections of BMP files, the snippet can automatically produce 150 × 150 pixel previews to display in the UI without slowing down navigation.
 * 3. When preparing BMP assets for an e‑learning platform, the code helps batch‑process source images into uniform thumbnail size for consistent layout across course modules.
 * 4. When implementing a content‑management system that stores BMP uploads, the routine can generate thumbnail versions on the server side for quick visual indexing and search results.
 * 5. When developing a digital asset management tool that requires periodic thumbnail regeneration after image edits, this example shows how to resize BMP files to a fixed dimension using C# and Aspose.Imaging.
 */