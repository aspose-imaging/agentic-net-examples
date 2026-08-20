// HOW-TO: Batch Convert BMP to SVG with Median Filter and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for processing
                    RasterImage raster = (RasterImage)image;

                    // Apply median filter with size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    // Resize to 300x300 pixels
                    raster.Resize(300, 300);

                    // Save as SVG using default options
                    SvgOptions svgOptions = new SvgOptions();
                    raster.Save(outputPath, svgOptions);
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
 * 1. When you need to clean up a large set of scanned BMP drawings, remove noise with a median filter, shrink them to a uniform 300 × 300 size, and store them as scalable SVG files for web display.
 * 2. When a legacy application exports graphics as BMP and you must prepare them for responsive UI components by converting them to lightweight vector SVG while applying a noise‑reducing filter.
 * 3. When an automated pipeline must process thousands of BMP icons, apply a median filter to improve visual quality, resize them to a standard thumbnail size, and output SVG for use in modern dashboards.
 * 4. When you are migrating a digital archive of BMP photographs to a format that scales without loss, and you want to batch‑process them with noise reduction and size normalization in C#.
 * 5. When a reporting tool requires vector graphics but the source images are BMP, you can programmatically filter, resize, and convert them to SVG to ensure crisp rendering at any resolution.
 */
