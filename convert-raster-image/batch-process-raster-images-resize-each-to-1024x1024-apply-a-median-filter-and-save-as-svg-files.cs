// HOW-TO: Batch Resize Images to 1024x1024, Apply Median Filter, Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input raster images
            string[] inputFiles = new[]
            {
                @"C:\Images\input1.png",
                @"C:\Images\input2.jpg",
                @"C:\Images\input3.bmp"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output SVG path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x1024 using the default resampling method
                    image.Resize(1024, 1024);

                    // Apply a median filter (size 5) to the entire image
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
                    }

                    // Prepare SVG save options with appropriate rasterization settings
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = new Size(1024, 1024)
                        }
                    };

                    // Save the processed image as SVG
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to batch‑process a folder of PNG, JPG, or BMP photos, resize them to a uniform 1024 × 1024 canvas, reduce noise with a median filter, and output scalable SVG files for web galleries.
 * 2. When preparing scanned documents for vector‑based annotation, you can resize each raster page, smooth out speckles with a median filter, and convert the result to SVG to retain editability.
 * 3. When generating icon assets for a responsive UI, this code lets you take existing raster icons, standardize their size, clean up edges, and produce SVG versions that scale without quality loss.
 * 4. When feeding images into a machine‑learning pipeline that expects fixed‑size inputs, you can resize, denoise, and store the pre‑processed data as SVG to keep file size low while preserving visual detail.
 * 5. When creating printable graphics that must be resized and cleaned before vector conversion, the script automates the workflow for multiple raster files, applying a median filter and exporting them as SVG for high‑resolution output.
 */
