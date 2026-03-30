using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "input_multi_page.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory for processed pages
        string outputDir = "output_pages";
        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to multipage interface
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded image is not a multipage image.");
                return;
            }

            // Iterate through each page
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Retrieve the page image
                using (Image pageImage = multipage.Pages[i])
                {
                    // Ensure the page is a raster image
                    RasterImage raster = pageImage as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Page {i} is not a raster image.");
                        continue;
                    }

                    // Apply Gaussian blur filter (radius 5, sigma 4.0)
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDir, $"page_{i}.png");

                    // Ensure the output directory exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed page as PNG
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
                }
            }
        }
    }
}