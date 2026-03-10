using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source image
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "sample.png");
        string outputPath = System.IO.Path.Combine(dir, "sample.Filtered.png");

        // Load the image (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Identify all concrete filter option classes available in the library
            var filterOptionTypes = typeof(FilterOptionsBase).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(FilterOptionsBase)))
                .Select(t => t.Name)
                .OrderBy(name => name)
                .ToList();

            Console.WriteLine("Supported filter options:");
            foreach (var name in filterOptionTypes)
            {
                Console.WriteLine("- " + name);
            }

            // Example: apply a Median filter (kernel size = 5) to the whole image
            // The Filter method is defined on RasterImage and its derived classes
            if (image is RasterImage rasterImage)
            {
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the processed image (lifecycle rule)
                rasterImage.Save(outputPath);
                Console.WriteLine($"Filtered image saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("The loaded image type does not support the Filter method.");
            }
        }
    }
}