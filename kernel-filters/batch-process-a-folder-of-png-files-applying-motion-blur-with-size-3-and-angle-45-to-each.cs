// HOW-TO: Apply Motion Blur to All PNG Images in a Folder Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_blurred.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(3, 45.0, 1.0));

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, options);
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
 * 1. When you need to automatically add a subtle motion‑blur effect to a large set of product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to preprocess a folder of PNG screenshots with a 45‑degree motion blur to simulate camera movement for a game UI prototype.
 * 3. When you must generate blurred placeholders for web pages by applying a size‑3 motion blur to every PNG asset in a design assets directory.
 * 4. When you are creating a batch image pipeline that reads PNG files, applies a motion‑wiener filter, and saves the results with a “_blurred” suffix for further analysis.
 * 5. When you need to automate the preparation of PNG textures for a video‑editing workflow by applying a consistent motion blur across all files in a source folder.
 */
