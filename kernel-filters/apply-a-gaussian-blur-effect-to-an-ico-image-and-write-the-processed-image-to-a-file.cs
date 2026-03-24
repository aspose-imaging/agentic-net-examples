using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to IcoImage to access pages
            IcoImage ico = (IcoImage)image;

            // Apply Gaussian blur to each page in the ICO
            foreach (var page in ico.Pages)
            {
                // Each page is an Image; cast to RasterImage for filtering
                if (page is RasterImage rasterPage)
                {
                    // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole page
                    rasterPage.Filter(rasterPage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                }
            }

            // Save the processed ICO image
            ico.Save(outputPath);
        }
    }
}