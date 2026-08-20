// HOW-TO: Apply Motion Blur to All PNG Images in a Folder Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input folder
            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string file in files)
            {
                string inputPath = file;

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(file) + "_motion.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply motion blur, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    // Motion blur with length 3, smooth factor 1.0, angle 45 degrees
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 45.0));
                    raster.Save(outputPath);
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
 * 1. When you need to automatically add a subtle motion effect to a large set of product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to preprocess a folder of PNG screenshots with a 45‑degree motion blur of length 3 to simulate camera movement for a video game UI demo.
 * 3. When a batch of PNG assets must be prepared with consistent motion blur for a marketing animation pipeline using C# and Aspose.Imaging.
 * 4. When you are building a server‑side service that receives PNG uploads and applies a standard motion‑blur filter before saving them to a CDN.
 * 5. When you need to quickly generate blurred placeholders for lazy‑loading images by processing all PNG files in a directory with a fixed blur angle and size.
 */
