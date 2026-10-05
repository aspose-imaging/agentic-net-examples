// HOW-TO: Rasterize SVG, Apply Sharpen Filter, and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Rasterize SVG to PNG
            using (Image svgImg = Image.Load(inputPath))
            {
                var pngOpts = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImg.Width,
                        PageHeight = svgImg.Height
                    }
                };
                svgImg.Save(tempPngPath, pngOpts);
            }

            // Load rasterized PNG and apply custom convolution kernel
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                // Create new SVG and embed the filtered raster image
                int width = raster.Width;
                int height = raster.Height;
                var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, 96);
                svgGraphics.DrawImage(raster, new Point(0, 0));
                SvgImage resultSvg = svgGraphics.EndRecording();

                resultSvg.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to enhance an SVG logo with a custom sharpening filter but must deliver the final artwork still as an SVG file for web scalability.
 * 2. When a reporting tool generates vector diagrams that require pixel‑level adjustments, such as edge enhancement, before embedding them back into SVG reports.
 * 3. When an e‑commerce platform wants to apply a brand‑specific image effect to product illustrations stored as SVG without converting the whole catalog to raster formats.
 * 4. When a GIS application must rasterize complex map SVGs, apply a convolution filter to improve visual contrast, and then re‑package them as SVG for downstream vector‑aware tools.
 * 5. When a CI/CD pipeline automates image preprocessing by converting SVG assets to PNG, applying a custom kernel, and recreating SVGs to keep the original file type for downstream designers.
 */
