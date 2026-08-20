// HOW-TO: Create JPEG Thumbnails For All Images In A Folder Using C# (Aspose.Imaging for .NET)
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
            // Input/Output directory setup (atomic block as required)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Process each JPEG file
            foreach (string inputPath in files)
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Simple filter for JPEG extensions
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                {
                    continue;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to thumbnail size (e.g., 100x100)
                    int thumbWidth = 100;
                    int thumbHeight = 100;
                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    // Prepare output path in a subdirectory
                    string thumbDir = Path.Combine(outputDirectory, "Thumbnails");
                    string outputPath = Path.Combine(thumbDir, Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save thumbnail as JPEG
                    using (JpegOptions options = new JpegOptions())
                    {
                        options.Quality = 90;
                        image.Save(outputPath, options);
                    }
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
 * 1. When you need to generate small preview images for a web gallery from a batch of JPEG photos.
 * 2. When an e‑commerce site must automatically create product thumbnail icons from uploaded product pictures.
 * 3. When a desktop application has to prepare thumbnail caches for faster image browsing in a file explorer.
 * 4. When a content management system imports a folder of JPEGs and stores reduced‑size versions for mobile devices.
 * 5. When a photo‑processing pipeline requires resizing all incoming JPEGs to a fixed 100 × 100 size for PDF thumbnail pages.
 */
