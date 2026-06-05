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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options for PNG output
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG to a memory stream
                    using (var rasterStream = new MemoryStream())
                    {
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load the rasterized image as a RasterImage
                        using (Image rasterImage = Image.Load(rasterStream))
                        {
                            // Cast to RasterImage to apply filters
                            var raster = (RasterImage)rasterImage;

                            // Apply Gaussian blur with size 5 and sigma 2.0
                            var blurOptions = new GaussianBlurFilterOptions(5, 2.0);
                            raster.Filter(raster.Bounds, blurOptions);

                            // Save the processed image
                            raster.Save(outputPath);
                        }
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
 * 1. When a web designer needs to batch‑process a folder of SVG icons into blurred PNG thumbnails for faster page loading and consistent visual style.
 * 2. When an e‑commerce platform automatically applies a soft‑focus Gaussian blur (sigma 2.0) to product vector graphics before exporting them as PNGs for mobile app displays.
 * 3. When a marketing team creates blurred PNG versions of SVG logos to use as subtle background watermarks in email newsletters and promotional PDFs.
 * 4. When a GIS application converts detailed SVG map layers into raster PNG tiles with a Gaussian blur to enhance visual hierarchy in multi‑layer map visualizations.
 * 5. When a game developer preprocesses SVG assets by applying a sigma 2.0 Gaussian blur and exporting them as PNG sprites for real‑time rendering pipelines.
 */