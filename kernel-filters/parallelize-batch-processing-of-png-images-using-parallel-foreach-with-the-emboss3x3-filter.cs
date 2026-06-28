using System;
using System.IO;
using Aspose.Imaging;
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "_emboss.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, filterOptions);

                    using (var saveOptions = new PngOptions())
                    {
                        raster.Save(outputPath, saveOptions);
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When an e‑commerce platform needs to quickly generate embossed PNG thumbnails for thousands of product photos to create a consistent 3‑D look, this parallel filter code speeds up the batch processing.
 * 2. When a game development studio wants to apply an emboss 3×3 effect to a large set of sprite sheets stored as PNG files before importing them into the engine, the code runs the operation concurrently for faster asset preparation.
 * 3. When a web service processes user‑uploaded PNG avatars and must add a subtle embossed border to each image in real time, using Parallel.ForEach reduces latency across many simultaneous uploads.
 * 4. When a publishing company digitizes scanned PNG pages and applies an emboss filter to enhance edge contrast before OCR, the parallelized routine accelerates the batch conversion of hundreds of pages.
 * 5. When a marketing team creates a series of stylized PNG banners with an emboss effect for a promotional campaign, the code enables rapid, automated processing of all design files in parallel.
 */