using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG (or any vector multipage) image
        using (Image image = Image.Load(inputPath))
        {
            // Try to treat it as a multipage image
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage != null)
            {
                // Process each page/frame
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Temporary raster file for the current page
                    string tempPath = $"temp_page_{i}.png";
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                    // Obtain vector rasterization options for proper rendering
                    var vectorOptions = (Aspose.Imaging.ImageOptions.VectorRasterizationOptions)image.GetDefaultOptions(
                        new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });

                    // Set up PNG save options with rasterization and single‑page export
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(i, 1))
                    };

                    // Save the current page as a raster PNG
                    image.Save(tempPath, pngOptions);

                    // Load the raster PNG, apply Sharpen3x3 filter, and overwrite the file
                    using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                    {
                        raster.Filter(raster.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                        raster.Save(tempPath);
                    }
                }

                // Save the (unchanged) vector document to the output path
                image.Save(outputPath);
            }
            else
            {
                // Single‑page handling (same logic without page loop)
                string tempPath = "temp.png";
                Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                var vectorOptions = (Aspose.Imaging.ImageOptions.VectorRasterizationOptions)image.GetDefaultOptions(
                    new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });

                var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
                image.Save(tempPath, pngOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                {
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                    raster.Save(tempPath);
                }

                image.Save(outputPath);
            }
        }
    }
}