// HOW-TO: Batch Apply Emboss 5x5 Filter to PNG Images with C# (Aspose.Imaging for .NET)
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
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_embossed.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                    raster.Save(outputPath);
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
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
 * 1. When you need to automatically add a 3‑D emboss effect to a large set of PNG assets for a game UI.
 * 2. When you want to preprocess product photos by applying a uniform emboss filter before uploading them to an e‑commerce site.
 * 3. When a desktop application must generate stylized thumbnails from user‑uploaded PNGs without manual editing.
 * 4. When a build pipeline should enhance documentation screenshots with an emboss effect as part of automated asset preparation.
 * 5. When you are creating a batch script to convert raw PNG scans into embossed images for artistic print projects.
 */
