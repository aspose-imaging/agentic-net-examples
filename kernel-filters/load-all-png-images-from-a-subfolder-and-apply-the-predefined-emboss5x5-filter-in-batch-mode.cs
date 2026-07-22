using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.png", SearchOption.AllDirectories);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_embossed.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
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
 * 1. When a developer needs to automatically add a subtle 3‑D emboss effect to a large collection of product PNG thumbnails stored in subfolders before uploading them to an e‑commerce site.
 * 2. When a photo‑editing application must process user‑uploaded PNG assets in bulk and apply the predefined Emboss5x5 convolution filter to enhance texture for a game’s UI sprites.
 * 3. When a content‑management system has to generate embossed preview images for all PNG diagrams in a documentation repository without manual intervention.
 * 4. When a batch‑image‑conversion tool is required to read PNG files from nested directories, apply a fast convolution filter, and save the results with a suffix for later use in marketing materials.
 * 5. When an automated build pipeline needs to validate that every PNG asset in a project’s asset folder receives a consistent emboss effect using Aspose.Imaging for .NET before packaging the final release.
 */