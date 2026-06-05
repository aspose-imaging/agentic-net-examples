using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg.Graphics;
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
            string tempPngPath = "temp.png";
            string outputPath = "output.svg";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = ((SvgImage)svgImage).Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Define a custom convolution kernel (sharpen)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save filtered raster to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    raster.Save(ms, new PngOptions());
                    ms.Position = 0;

                    // Load filtered raster for drawing
                    using (RasterImage filteredRaster = (RasterImage)Image.Load(ms))
                    {
                        // Create a new SVG canvas matching the raster size
                        var svgGraphics = new SvgGraphics2D(filteredRaster.Width, filteredRaster.Height, 96);
                        // Draw the filtered raster onto the SVG
                        svgGraphics.DrawImage(filteredRaster, new Point(0, 0));

                        // Finalize SVG and save
                        using (SvgImage finalSvg = svgGraphics.EndRecording())
                        {
                            finalSvg.Save(outputPath);
                        }
                    }
                }
            }

            // Clean up temporary PNG
            if (File.Exists(tempPngPath))
                File.Delete(tempPngPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to sharpen the visual details of an SVG logo before embedding it in a web page while still keeping the file in SVG format for scalability.
 * 2. When a CI/CD pipeline must automatically apply a custom image filter to SVG icons, rasterize them to PNG for processing, and then re‑export the result as SVG to maintain vector compatibility.
 * 3. When a graphics application wants to enhance scanned SVG diagrams with edge‑enhancement using a convolution kernel without losing the original vector paths.
 * 4. When an e‑learning platform requires batch processing of SVG illustrations to improve contrast via a sharpen filter, using C# and Aspose.Imaging, and then deliver the edited graphics as SVG files.
 * 5. When a developer is building a .NET service that converts user‑uploaded SVG artwork to a filtered version for printing, applying a custom kernel and preserving vector data for high‑resolution output.
 */