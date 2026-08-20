// HOW-TO: Apply Sharpen3x3 Filter to Multiple Images and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Collection of image file names to process
            string[] files = new string[]
            {
                "sample1.svg",
                "sample2.cdr",
                "sample3.png"
            };

            foreach (var fileName in files)
            {
                string inputPath = Path.Combine(inputDirectory, fileName);

                // Check input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image (raster or vector)
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG save options
                    PngOptions pngOptions = new PngOptions();

                    // Determine output file path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(fileName) + ".png");

                    // Ensure output directory exists for the file
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    if (image is RasterImage raster)
                    {
                        // Apply Sharpen3x3 filter
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                        raster.Save(outputPath, pngOptions);
                    }
                    else if (image is VectorImage)
                    {
                        // Set vector rasterization options
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            BackgroundColor = Aspose.Imaging.Color.White
                        };
                        image.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑process a mix of SVG, CDR and PNG drawings, sharpen them with a 3×3 filter, and output high‑quality PNG files while keeping the original vector information.
 * 2. When a graphics‑heavy web application must automatically enhance uploaded vector illustrations and raster images before storing them as PNG thumbnails.
 * 3. When a desktop utility has to convert legacy CorelDRAW files to PNG for cross‑platform compatibility while improving edge clarity through sharpening.
 * 4. When an automated build pipeline should generate sharpened PNG assets from design sources to ensure consistent visual quality in UI resources.
 * 5. When a reporting tool requires converting various drawing formats into PNG with preserved vector data for inclusion in PDF or HTML reports.
 */
