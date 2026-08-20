// HOW-TO: Resize Image to 1200x1200 Apply Median Filter and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.svg";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster‑specific operations
                RasterImage raster = (RasterImage)image;

                // Resize to 1200x1200 pixels (default NearestNeighbourResample)
                raster.Resize(1200, 1200);

                // Apply a median filter with a kernel size of 5 to the whole image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Prepare SVG saving options with appropriate rasterization settings
                var svgOptions = new SvgOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set the page size to match the raster image dimensions
                    PageSize = raster.Size
                };
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a scalable SVG thumbnail from a high‑resolution JPEG while reducing noise, you can resize the image to 1200×1200, apply a median filter, and save it as SVG using Aspose.Imaging in C#.
 * 2. When preparing graphics for responsive web design, you may want to convert raster photos to vector‑compatible SVG files with a fixed size and denoised appearance, which this code accomplishes.
 * 3. When automating a batch process that cleans up scanned documents before embedding them in PDFs, applying a median filter after resizing ensures consistent quality and the SVG output preserves layout fidelity.
 * 4. When creating icons for mobile apps that require a specific pixel dimension and smooth edges, resizing to 1200×1200 and filtering the source image before exporting to SVG simplifies the workflow.
 * 5. When integrating image preprocessing into a C# backend service that receives user‑uploaded photos, this snippet can standardize size, remove speckle noise, and convert the result to an SVG for further vector manipulation.
 */
