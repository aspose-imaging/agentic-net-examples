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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page PNG (APNG)
            using (Image image = Image.Load(inputPath))
            {
                // Process each page if the image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        // Each page is an Image; cast to RasterImage for filtering
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            // Apply Gaussian blur to the entire page
                            page.Filter(
                                page.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                        }
                    }
                }

                // Save the processed image as a multi‑page PNG (APNG)
                image.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}