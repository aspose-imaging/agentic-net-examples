// HOW-TO: Batch Apply Motion Wiener Filter To Low Light PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    var rect = new Rectangle(0, 0, raster.Width, raster.Height);
                    raster.Filter(rect, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 0.5, 0.5));

                    using (PngOptions options = new PngOptions())
                    {
                        options.Source = new FileCreateSource(outputPath, false);
                        raster.Save(outputPath, options);
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
 * 1. When you need to automatically clean up a folder of night‑time PNG photos that suffer from motion blur before publishing them online.
 * 2. When a surveillance system stores low‑light PNG frames and you want to reduce motion artifacts in all files with a single C# routine.
 * 3. When preparing a dataset of PNG images captured in dark environments for machine‑learning training and you must apply a motion‑Wiener filter to each image.
 * 4. When developing a desktop utility that processes user‑uploaded PNG screenshots taken in dim lighting and improves their clarity without manual editing.
 * 5. When integrating Aspose.Imaging into a batch‑processing pipeline to enhance PNG images from a wildlife camera trap that were taken with fast motion in low illumination.
 */
