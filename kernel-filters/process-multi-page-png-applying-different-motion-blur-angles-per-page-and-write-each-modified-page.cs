using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image (expected to be a multi‑page PNG / APNG)
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        // Extract the page as a RasterImage
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            // Define a unique motion blur angle for each page
                            double angle = i * 30.0; // example: 0°, 30°, 60°, ...

                            // Create motion blur filter options (length, sigma, angle)
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, angle);

                            // Apply the filter to the entire page
                            page.Filter(page.Bounds, filterOptions);

                            // Prepare output file name for the modified page
                            string outputPath = $"output_page{i}.png";

                            // Ensure the output directory exists
                            string outputDir = Path.GetDirectoryName(outputPath);
                            if (!string.IsNullOrWhiteSpace(outputDir))
                            {
                                Directory.CreateDirectory(outputDir);
                            }

                            // Save the modified page as PNG
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("Input image is not a multipage image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}