using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    raster.Save(outputPath);
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
 * 1. When a developer needs to apply an emboss effect to thousands of PNG files in a folder to generate stylized thumbnails for an e‑commerce catalog, they can use this Parallel.ForEach code with Aspose.Imaging’s Emboss3x3 filter.
 * 2. When a photo‑editing web service must quickly process user‑uploaded PNG images on a server and add a 3×3 emboss filter before storing them, the parallel batch routine speeds up the workload.
 * 3. When an automated build pipeline has to convert a set of PNG assets into embossed versions for a game’s UI theme, this C# example shows how to run the convolution filter concurrently.
 * 4. When a desktop application needs to generate embossed previews of PNG diagrams for a documentation generator without blocking the UI thread, the Parallel.ForEach approach handles the processing in the background.
 * 5. When a cloud function processes incoming PNG files from a storage bucket and applies a convolution emboss filter to each file for visual effect, the code demonstrates scalable parallel execution with Aspose.Imaging.
 */