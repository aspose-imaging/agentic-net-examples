// HOW-TO: Apply Horizontal Motion Wiener Filter to PNG Image in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 0.0);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce horizontal motion blur in a video frame saved as a PNG before further analysis.
 * 2. When you want to improve the visual quality of surveillance footage by applying a motion‑Wiener filter to each extracted PNG snapshot.
 * 3. When processing a batch of PNG images captured from a moving camera and you require automated de‑blurring using Aspose.Imaging in C#.
 * 4. When preparing PNG assets for computer‑vision algorithms and you must remove directional blur to enhance edge detection.
 * 5. When building a C# application that cleans up horizontally blurred PNG screenshots from a streaming video source.
 */
