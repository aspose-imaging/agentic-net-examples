using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG from the SVG
            string tempPngPath = "temp_raster.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load the SVG and rasterize it to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size for rasterization
                    PageSize = svgImage.Size
                };
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                svgImage.Save(tempPngPath, pngSaveOptions);
            }

            // Load the rasterized PNG, apply the Sharpen3x3 convolution filter, and save the final PNG
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
            {
                // Apply the predefined 3x3 sharpen kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                // Save the sharpened image as PNG
                rasterImage.Save(outputPath, new PngOptions());
            }

            // Clean up the temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a web application needs to convert user‑uploaded SVG icons into high‑resolution PNG thumbnails with enhanced edge definition, this code rasterizes the SVG and applies a Sharpen3x3 filter before saving the result.
 * 2. When an e‑commerce platform generates product catalog images from vector SVG templates and wants to improve visual sharpness for print‑ready PNG files, the code performs the rasterization and sharpening in one workflow.
 * 3. When a reporting tool creates SVG charts that must be embedded in PDF reports as PNG images with clearer lines, developers can use this snippet to rasterize and sharpen the charts automatically.
 * 4. When a mobile app processes SVG assets on the server side and needs to deliver optimized PNG assets with boosted detail for faster loading, the code provides the necessary SVG‑to‑PNG conversion and sharpening step.
 * 5. When a content management system batch‑processes SVG logos to produce sharpened PNG versions for use on high‑DPI displays, this example shows how to load, rasterize, filter, and save each image using Aspose.Imaging for .NET.
 */