using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_motion.png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply motion blur, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    // Apply motion blur with size 3, smooth 1.0, angle 45 degrees
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(3, 1.0, 45.0));
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
 * 1. When preparing a product catalog, a developer can batch‑process PNG product photos to add a subtle motion blur effect, making static images appear dynamic for web‑ready thumbnails.
 * 2. When creating a series of game sprites, a developer may apply a 45‑degree motion blur to all PNG frames to simulate fast movement without manually editing each file.
 * 3. When generating promotional banners, a developer can automatically blur background PNG layers, ensuring foreground text remains sharp while the background gains a motion‑styled depth.
 * 4. When converting scanned PNG documents into stylized visual assets, a developer can use motion blur to give the pages a cinematic look for presentations or slideshows.
 * 5. When building an automated photo‑filter pipeline, a developer can apply a size‑3, 45‑degree motion blur to every PNG uploaded to a folder, delivering consistent artistic effects across the entire image set.
 */