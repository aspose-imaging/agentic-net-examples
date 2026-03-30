using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "input_multi.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

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

            // Iterate over each page
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Retrieve the page as an Image
                Image pageImage = multipage.Pages[i];

                // Ensure the page is disposed after processing
                using (pageImage)
                {
                    // Cast to RasterImage for filtering
                    RasterImage raster = (RasterImage)pageImage;

                    // Apply motion wiener filter: size 5, smooth 1.0, angle 90 degrees
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(5, 1.0, 90.0));

                    // Prepare output file path for this page
                    string outputPath = $"output_page_{i}.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the filtered page as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}