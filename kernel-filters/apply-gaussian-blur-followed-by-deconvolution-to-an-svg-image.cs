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
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string tempRasterPath = "temp.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG -> raster conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Save the rasterized image to a temporary PNG file
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                svgImage.Save(tempRasterPath, pngOptions);
            }

            // Load the temporary raster image for filtering
            using (Image image = Image.Load(tempRasterPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Gauss-Wiener deconvolution (radius 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

                // Save the final processed image
                rasterImage.Save(outputPath);
            }

            // Optionally delete the temporary raster file
            if (File.Exists(tempRasterPath))
            {
                File.Delete(tempRasterPath);
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
 * 1. When a developer needs to soften vector graphics from an SVG before converting them to a high‑resolution PNG for web thumbnails, they can apply a Gaussian blur followed by deconvolution to preserve edge detail while reducing noise.
 * 2. When preparing SVG icons for inclusion in a printed brochure, a developer can rasterize the SVG, blur it to simulate printing diffusion, and then deconvolve to sharpen the result, ensuring crisp output in the final PNG.
 * 3. When building an image‑processing pipeline that receives user‑uploaded SVG logos, a developer can use this code to blur the rasterized image to remove small artifacts and then deconvolve to restore sharpness before storing the PNG in a content‑delivery network.
 * 4. When creating visual effects for a game UI where SVG assets must be converted to raster textures with a soft glow, a developer can apply Gaussian blur to generate the glow and then deconvolution to keep the underlying shapes clear in the output PNG.
 * 5. When automating the generation of PDF reports that embed SVG diagrams, a developer can rasterize the SVG, apply Gaussian blur to reduce aliasing, and then use Gauss‑Wiener deconvolution to enhance line clarity before embedding the processed PNG into the PDF.
 */