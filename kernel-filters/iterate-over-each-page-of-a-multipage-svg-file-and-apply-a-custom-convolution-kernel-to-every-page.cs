using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputDir = "output_pages";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multipage SVG image
            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                int pageIndex = 0;
                foreach (Image page in multipage.Pages)
                {
                    // Rasterize the current page to a PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var rasterOptions = new SvgRasterizationOptions
                        {
                            PageSize = page.Size
                        };

                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        page.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load the rasterized page as a RasterImage
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Define a custom 3x3 convolution kernel (sharpen)
                            double[,] kernel = new double[,]
                            {
                                { 0, -1, 0 },
                                { -1, 5, -1 },
                                { 0, -1, 0 }
                            };

                            var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                            // Apply the convolution filter to the entire raster image
                            raster.Filter(raster.Bounds, convOptions);

                            // Save the filtered raster image to a PNG file
                            string outPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                            raster.Save(outPath, new PngOptions());
                        }
                    }

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the visual sharpness of every page in a multi‑page SVG brochure before converting it to PNG thumbnails, they can iterate over each page and apply a custom 3×3 convolution kernel.
 * 2. When an automated publishing pipeline must apply a consistent edge‑detection filter to all layers of a multi‑page SVG diagram and save the results as raster images, this code provides the page‑by‑page processing.
 * 3. When a web service generates printable PDFs from multi‑page SVG assets and wants to pre‑process each page with a custom blur or emboss filter using Aspose.Imaging for .NET, the example shows how to rasterize and convolve each page.
 * 4. When a batch‑conversion tool needs to convert a multi‑page SVG logo set into high‑resolution PNG files while applying a custom sharpening kernel to improve readability on screens, the code iterates through pages and applies the filter.
 * 5. When a quality‑control script must verify that a custom convolution filter (e.g., noise reduction) is correctly applied to every page of a multi‑page SVG illustration before archiving, this approach loads each page, rasterizes it, and runs the kernel.
 */