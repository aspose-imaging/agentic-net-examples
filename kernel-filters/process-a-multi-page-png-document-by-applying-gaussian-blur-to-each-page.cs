using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input/multipage.png";
            string outputPath = "output/blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Process only if the image supports multiple pages
                if (image is IMultipageImage multipageImage)
                {
                    // Iterate through each page and apply Gaussian blur
                    foreach (Image page in multipageImage.Pages)
                    {
                        if (page is RasterImage rasterPage)
                        {
                            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole page
                            rasterPage.Filter(rasterPage.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                        }
                    }
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}