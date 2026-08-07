using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";
            string tempPngPath = "temp.png";
            string filteredPngPath = "filtered.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG
            using (Image img = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)img;

                // Rasterize SVG to PNG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Define custom kernel (sharpen)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply convolution filter
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(filteredPngPath, new PngOptions());
            }

            // Load filtered raster image
            using (RasterImage filtered = (RasterImage)Image.Load(filteredPngPath))
            {
                // Create new SVG canvas
                int width = filtered.Width;
                int height = filtered.Height;
                int dpi = 96;
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw filtered raster onto SVG
                graphics.DrawImage(filtered, new Point(0, 0));

                // Finalize SVG and save
                using (SvgImage finalSvg = graphics.EndRecording())
                {
                    finalSvg.Save(outputPath, new SvgOptions());
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
 * 1. When a web application must generate a high‑resolution PNG preview of an SVG logo, apply a sharpening filter, and then embed the edited image back into an SVG file for further vector editing.
 * 2. When an e‑commerce platform needs to automatically enhance product SVG icons by rasterizing them, applying a custom convolution kernel to improve edge definition, and re‑exporting them as SVG to keep the file size small.
 * 3. When a reporting tool converts complex SVG charts into raster images, sharpens the details with a convolution filter, and then saves the result as SVG so that the final report remains fully scalable.
 * 4. When a desktop publishing software wants to batch‑process SVG illustrations, apply a user‑defined filter such as emboss or blur via a kernel, and preserve the vector structure by saving the output as SVG.
 * 5. When a mobile app prepares SVG assets for different screen densities by rasterizing, applying a custom image filter for visual consistency, and then re‑embedding the filtered raster back into an SVG container for responsive rendering.
 */