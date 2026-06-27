using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_motion.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 45.0));

                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to automatically add a motion blur effect to a collection of PNG product photos before uploading them to an e‑commerce site.
 * 2. When a game asset pipeline requires batch processing of sprite sheets to simulate movement by applying a 3‑pixel motion blur at a 45‑degree angle.
 * 3. When a marketing team wants to generate stylized PNG banners with consistent motion blur for a social media campaign using C# and Aspose.Imaging.
 * 4. When a photo‑editing application must convert user‑uploaded PNG images into motion‑blurred thumbnails for faster preview generation.
 * 5. When an automated build script has to preprocess PNG icons by applying a motion Wiener filter to improve visual consistency across different screen resolutions.
 */