using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputDir = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to multipage interface
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded image does not support multiple pages.");
                return;
            }

            int pageCount = multipage.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                // Temporary PNG path for rasterizing the current page
                string tempPngPath = Path.Combine(outputDir, $"temp_page_{i}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                // Set up PNG options with vector rasterization and single‑page export
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size
                    },
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                };

                // Rasterize the current page to a temporary PNG file
                image.Save(tempPngPath, pngOptions);

                // Load the rasterized page
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    // Apply motion Wiener filter (size=6, smooth=1.0, angle=75)
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(6, 1.0, 75.0));

                    // Final output path for the filtered page
                    string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the filtered raster image
                    raster.Save(outputPath);
                }

                // Optionally delete the temporary file
                try { File.Delete(tempPngPath); } catch { }
            }
        }
    }
}