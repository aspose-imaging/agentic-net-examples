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
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the image as a multipage image
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage != null && multipage.PageCount > 0)
                {
                    int pageIndex = 0;
                    foreach (Image page in multipage.Pages)
                    {
                        using (RasterImage raster = (RasterImage)page)
                        {
                            // Custom 3x3 kernel normalized to sum = 1
                            double[,] kernel = new double[,]
                            {
                                { 0.0625, 0.125, 0.0625 },
                                { 0.125,  0.25,  0.125  },
                                { 0.0625, 0.125, 0.0625 }
                            };

                            // Apply convolution filter
                            raster.Filter(
                                raster.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                            // Prepare output path for the current page
                            string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed page as PNG
                            raster.Save(outputPath, new PngOptions());
                        }
                        pageIndex++;
                    }
                }
                else
                {
                    // Single‑page handling
                    using (RasterImage raster = (RasterImage)image)
                    {
                        double[,] kernel = new double[,]
                        {
                            { 0.0625, 0.125, 0.0625 },
                            { 0.125,  0.25,  0.125  },
                            { 0.0625, 0.125, 0.0625 }
                        };

                        raster.Filter(
                            raster.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                        string outputPath = Path.Combine(outputDirectory, "page_0.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract each frame from a multi‑page PNG (such as an animated icon), apply a blur convolution kernel normalized to one, and save the processed frames as separate PNG files.
 * 2. When a medical imaging application must preprocess every slice of a multi‑page PNG scan with a Gaussian‑like kernel to reduce noise before further analysis.
 * 3. When a web‑based graphics tool wants to generate thumbnail versions of all pages in a multi‑page PNG while preserving overall brightness by using a normalized convolution filter.
 * 4. When an automated document‑archiving system has to clean each page of a multi‑page PNG invoice with a smoothing kernel and write the results to a folder for OCR processing.
 * 5. When a game developer needs to batch‑process sprite sheets stored as multi‑page PNGs, applying a custom sharpening kernel that sums to one to maintain color balance before exporting each sprite as an individual file.
 */