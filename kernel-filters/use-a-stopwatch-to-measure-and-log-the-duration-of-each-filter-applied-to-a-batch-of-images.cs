using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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

        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (var inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            var filters = new (string Name, FilterOptionsBase Options)[]
            {
                ("Median", new MedianFilterOptions(5)),
                ("Bilateral", new BilateralSmoothingFilterOptions(5)),
                ("Gaussian", new GaussianBlurFilterOptions(5, 4.0)),
                ("GaussWiener", new GaussWienerFilterOptions(5, 4.0)),
                ("MotionWiener", new MotionWienerFilterOptions(10, 1.0, 90.0)),
                ("Sharpen", new SharpenFilterOptions(5, 4.0))
            };

            foreach (var filter in filters)
            {
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                    Stopwatch sw = Stopwatch.StartNew();
                    raster.Filter(raster.Bounds, filter.Options);
                    sw.Stop();

                    Console.WriteLine($"{Path.GetFileName(inputPath)} - {filter.Name} filter took {sw.ElapsedMilliseconds} ms");

                    string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{filter.Name}.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
                }
            }
        }
    }
}