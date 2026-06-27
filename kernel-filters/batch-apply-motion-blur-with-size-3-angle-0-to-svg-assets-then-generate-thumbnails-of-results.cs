using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded directories
            string inputDir = "InputSvgs";
            string outputDir = "OutputSvgs";
            string thumbDir = "Thumbnails";

            // Ensure output directories exist
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(thumbDir);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output paths
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string blurredPath = Path.Combine(outputDir, fileNameWithoutExt + "_blurred.png");
                string thumbPath = Path.Combine(thumbDir, fileNameWithoutExt + "_thumb.png");

                // Ensure directories for each output file
                Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));
                Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));

                // Temporary rasterized PNG path
                string tempPng = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

                // Rasterize SVG to PNG
                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(tempPng, pngOptions);
                }

                // Apply motion blur filter to the rasterized image and save blurred version
                using (Image rasterImg = Image.Load(tempPng))
                {
                    var raster = (RasterImage)rasterImg;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 0.0));
                    raster.Save(blurredPath);
                }

                // Generate thumbnail (100x100) from blurred image
                using (Image blurredImg = Image.Load(blurredPath))
                {
                    var raster = (RasterImage)blurredImg;
                    raster.Resize(100, 100, ResizeType.NearestNeighbourResample);
                    raster.Save(thumbPath);
                }

                // Clean up temporary file
                if (File.Exists(tempPng))
                {
                    File.Delete(tempPng);
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
 * 1. When a developer needs to batch‑process a collection of SVG icons, apply a uniform motion blur (size 3, angle 0) and save the blurred results as PNG files for consistent UI styling.
 * 2. When an e‑commerce platform wants to generate blurred preview images of product vector graphics for a “loading” effect while also creating small thumbnails for catalog listings.
 * 3. When a marketing team requires automated conversion of SVG logos into blurred PNG assets for social‑media posts, with accompanying thumbnail versions for quick preview in a CMS.
 * 4. When a game developer must pre‑render motion‑blurred versions of SVG sprites and generate low‑resolution thumbnails for asset management tools.
 * 5. When a documentation generator needs to apply a subtle motion blur to SVG diagrams and produce thumbnail previews to embed in PDF or HTML help files.
 */