// HOW-TO: Batch Apply Gamma Correction to PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PSD files and rerun.");
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
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.AdjustGamma(2.2f);

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pngOptions = new PngOptions())
                    {
                        raster.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the brightness of a large set of Photoshop PSD layers for web publishing, you can batch‑adjust gamma and export them as PNGs using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must convert design assets from PSD to PNG while applying a 2.2 gamma curve to match monitor standards, this code provides the required processing.
 * 3. When a digital asset management system requires all incoming PSD files to be normalized for consistent visual appearance before storage, the script applies gamma correction and saves the result as PNG.
 * 4. When a game development workflow needs to prepare texture atlases by converting multiple PSD source files to gamma‑corrected PNGs for use in Unity, this example handles the conversion programmatically.
 * 5. When a photo‑editing SaaS platform wants to offer users a one‑click export that adjusts image luminance and outputs PNG files from uploaded PSDs, the code demonstrates the necessary steps in C#.
 */
