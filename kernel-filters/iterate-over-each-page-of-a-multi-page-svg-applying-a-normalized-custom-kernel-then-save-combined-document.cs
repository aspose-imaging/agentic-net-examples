using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the multi‑page SVG (or any vector image)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface if possible
                IMultipageImage multipage = image as IMultipageImage;
                List<Image> processedPages = new List<Image>();

                // Helper to process a single page
                void ProcessPage(Image pageImage)
                {
                    // Rasterization options for SVG
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = pageImage.Size
                    };

                    // Create a temporary raster image (PNG) bound to a temp file
                    string tempFile = Path.GetTempFileName();
                    FileCreateSource tempSource = new FileCreateSource(tempFile, false);
                    PngOptions pngOptions = new PngOptions { Source = tempSource };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Create raster image
                    Image rasterImg = Image.Create(pngOptions, pageImage.Width, pageImage.Height);
                    RasterImage raster = (RasterImage)rasterImg;

                    // Define a custom kernel (example 3x3 sharpen) and normalize it
                    double[,] kernel = new double[,]
                    {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };
                    double sum = 0;
                    foreach (double v in kernel) sum += v;
                    if (Math.Abs(sum) > 1e-6)
                    {
                        for (int i = 0; i < kernel.GetLength(0); i++)
                        {
                            for (int j = 0; j < kernel.GetLength(1); j++)
                            {
                                kernel[i, j] /= sum;
                            }
                        }
                    }

                    // Apply convolution filter
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                    // Add processed raster image to collection
                    processedPages.Add(rasterImg);
                }

                if (multipage != null && multipage.Pages != null && multipage.PageCount > 0)
                {
                    // Iterate over each page
                    foreach (Image page in multipage.Pages)
                    {
                        ProcessPage(page);
                        page.Dispose();
                    }
                }
                else
                {
                    // Single page fallback
                    ProcessPage(image);
                }

                // Create a multipage image from processed raster pages
                Image result = Image.Create(processedPages.ToArray());

                // Save as TIFF with default options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                result.Save(outputPath, tiffOptions);

                // Dispose result and all temporary pages
                result.Dispose();
                foreach (var page in processedPages)
                {
                    page.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}