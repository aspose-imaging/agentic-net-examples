using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputDir = "output";

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
                // Cast to multipage interface
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                int pageCount = multipage.PageCount;

                // Iterate over each page
                for (int i = 0; i < pageCount; i++)
                {
                    // Paths for temporary rasterized page and final filtered page
                    string tempPngPath = Path.Combine(outputDir, $"page_{i}.png");
                    string filteredPngPath = Path.Combine(outputDir, $"page_{i}_filtered.png");

                    // Rasterize the current page to PNG
                    var pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));
                    image.Save(tempPngPath, pngOptions);

                    // Load the rasterized PNG
                    using (Image rasterImage = Image.Load(tempPngPath))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Define a custom 3x3 convolution kernel (edge detection example)
                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        // Apply the convolution filter to the entire image
                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        // Save the filtered image
                        raster.Save(filteredPngPath);
                    }

                    // Optionally delete the temporary rasterized PNG
                    try
                    {
                        File.Delete(tempPngPath);
                    }
                    catch
                    {
                        // Ignore any errors during cleanup
                    }
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
 * 1. When a developer needs to batch‑process every page of a multi‑page SVG (such as an engineering drawing set) and apply a custom convolution kernel to enhance edges before exporting to PNG for printing.
 * 2. When an application must generate consistent visual effects (e.g., emboss or blur) across all layers of a multi‑page SVG brochure by rasterizing each page and applying a convolution filter in C# with Aspose.Imaging.
 * 3. When a workflow requires converting each page of a multi‑page SVG map into raster images, applying a sharpening kernel to improve readability, and saving the results as PNG files for GIS analysis.
 * 4. When a developer wants to preprocess every page of a multi‑page SVG comic strip with a noise‑reduction convolution filter before creating thumbnail PNGs for a web gallery.
 * 5. When an automated pipeline must extract each page of a multi‑page SVG invoice, apply a custom convolution to detect watermarks, and store the filtered PNGs for downstream OCR processing.
 */