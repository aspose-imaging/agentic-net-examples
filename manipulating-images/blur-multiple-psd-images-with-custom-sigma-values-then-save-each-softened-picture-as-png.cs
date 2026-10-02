// HOW-TO: Apply Gaussian Blur to Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.psd");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0);
                    raster.Filter(raster.Bounds, blurOptions);

                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑process a folder of Photoshop PSD layers to create softened preview thumbnails in PNG format for a web gallery.
 * 2. When an e‑commerce site requires automatically blurring product mockups stored as PSDs before publishing them as PNGs to protect proprietary designs.
 * 3. When a digital‑asset‑management system must generate low‑resolution, blurred PNG copies of high‑detail PSD artwork for quick loading in mobile apps.
 * 4. When a marketing automation workflow needs to apply a consistent Gaussian blur to client‑provided PSD files and export them as PNGs for social‑media posting.
 * 5. When a desktop application has to convert a collection of PSD files into PNGs while adding a custom blur effect to meet branding guidelines.
 */
