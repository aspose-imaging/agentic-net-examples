using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = new string[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.png"
            };

            string outputDir = @"C:\ProcessedImages";

            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    var filters = new (string suffix, Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase options)[]
                    {
                        ("Median", new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5)),
                        ("Gaussian", new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0)),
                        ("Sharpen", new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0))
                    };

                    foreach (var filter in filters)
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        raster.Filter(raster.Bounds, filter.options);
                        sw.Stop();

                        Console.WriteLine($"Applied {filter.suffix} filter to {Path.GetFileName(inputPath)} in {sw.ElapsedMilliseconds} ms.");

                        string outputPath = Path.Combine(outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_{filter.suffix}.png");

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        raster.Save(outputPath, new PngOptions());
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