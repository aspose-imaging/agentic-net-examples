using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            var filters = new (string Suffix, Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase Options)[]
            {
                ("Median", new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5)),
                ("Bilateral", new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5)),
                ("Gaussian", new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0)),
                ("Sharpen", new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0))
            };

            foreach (var filter in filters)
            {
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    DateTime start = DateTime.Now;
                    Console.WriteLine($"{filter.Suffix} filter start: {start:O}");

                    rasterImage.Filter(rasterImage.Bounds, filter.Options);

                    DateTime end = DateTime.Now;
                    Console.WriteLine($"{filter.Suffix} filter end: {end:O}");
                    Console.WriteLine($"{filter.Suffix} filter duration: {(end - start).TotalMilliseconds} ms");

                    string outputPath = Path.Combine(outputDirectory, $"sample_{filter.Suffix}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    rasterImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}