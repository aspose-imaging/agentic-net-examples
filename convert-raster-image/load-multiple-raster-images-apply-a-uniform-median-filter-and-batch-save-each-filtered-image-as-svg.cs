// HOW-TO: Batch Apply Median Filter to Raster Images and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded list of input raster image files to process.
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.png",
                @"C:\Images\sample2.jpg",
                @"C:\Images\sample3.bmp"
            };

            // Process each file individually.
            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists; report and skip if not.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output SVG path (same folder, same name, .svg extension).
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure the output directory exists to avoid DirectoryNotFoundException.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image, apply median filter, and save as SVG.
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering functionality.
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a median filter with a kernel size of 5 to the whole image.
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as SVG using default SVG options.
                    rasterImage.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Any unhandled exception is reported to the error stream.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce noise in a collection of PNG, JPEG, or BMP photos before converting them to scalable vector graphics for web display.
 * 2. When you want to automate the preprocessing of scanned documents by applying a median filter and exporting each as an SVG for further editing.
 * 3. When a batch workflow must transform multiple raster assets into SVG format while preserving edge clarity through noise reduction.
 * 4. When integrating image cleanup into a C# application that processes user‑uploaded images and stores the cleaned results as SVG files.
 * 5. When preparing graphics for responsive design, you apply a uniform median filter to several raster files and convert them to SVG in one pass.
 */
