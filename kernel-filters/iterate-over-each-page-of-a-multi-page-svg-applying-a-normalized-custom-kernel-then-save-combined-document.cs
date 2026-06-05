using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.tiff";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the multi‑page SVG
            using (Image svgImage = Image.Load(inputPath))
            {
                // Determine page count (fallback to 1 if not multipage)
                int pageCount = 1;
                if (svgImage is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    pageCount = multipage.PageCount;
                }

                // Prepare a list to hold processed raster pages
                List<Image> processedPages = new List<Image>();

                // Custom kernel (example 3x3 normalized kernel)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };
                // Normalize kernel
                double sum = 0;
                foreach (double v in kernel) sum += v;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }

                // Process each page
                for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
                {
                    // Rasterize current page to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        // Rasterization options for SVG
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageSize = svgImage.Size
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;
                        // Export only the current page
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1));
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized page
                        RasterImage rasterPage = (RasterImage)Image.Load(ms);
                        // Apply custom convolution filter
                        rasterPage.Filter(rasterPage.Bounds, new ConvolutionFilterOptions(kernel));
                        // Add the processed raster page to the list
                        processedPages.Add(rasterPage);
                    }
                }

                // Create a multipage image from the processed pages
                using (Image result = Image.Create(processedPages.ToArray(), true))
                {
                    // Save as multi‑page TIFF
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    result.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert each page of a multi‑page SVG into raster images, apply a normalized Gaussian blur kernel, and merge the results into a single multi‑page TIFF for printing or archival.
 * 2. When an application must preprocess vector graphics from an SVG catalog by smoothing edges with a custom convolution filter before generating a high‑resolution TIFF document for PDF creation.
 * 3. When a web service processes uploaded multi‑page SVG invoices, applies a sharpening filter using a normalized kernel, and stores the output as a multi‑page TIFF for compliance and OCR scanning.
 * 4. When a GIS tool transforms layered SVG maps into a combined TIFF file while applying a blur kernel to reduce visual noise across all map layers.
 * 5. When an e‑learning platform batch‑processes SVG slide decks, normalizes a convolution kernel to enhance readability, and saves the slides as a single multi‑page TIFF for offline viewing.
 */