using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try/catch to report any unexpected errors.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.svg";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering and resizing methods.
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with a kernel size of 5 to the whole image.
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Resize the image to a thumbnail size (e.g., 100x100 pixels).
                raster.Resize(100, 100);

                // Save the processed image as SVG.
                // SvgOptions are used to specify the target format.
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any error without crashing the process.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate small, noise‑reduced SVG icons from user‑uploaded PNG files for faster page loads.
 * 2. When an e‑commerce platform wants to create thumbnail previews of product photos while applying a median filter to remove compression artifacts before converting them to scalable SVG for responsive design.
 * 3. When a desktop utility must batch‑process scanned PNG documents, denoise them with a median filter, shrink them to 100 × 100 pixels, and save the results as SVG for vector‑based archiving.
 * 4. When a mobile app needs to display low‑resolution, clean thumbnails of PNG avatars in SVG format to maintain crispness on high‑DPI screens.
 * 5. When a reporting tool converts noisy PNG charts into compact SVG thumbnails for inclusion in PDF or HTML reports without losing visual quality.
 */