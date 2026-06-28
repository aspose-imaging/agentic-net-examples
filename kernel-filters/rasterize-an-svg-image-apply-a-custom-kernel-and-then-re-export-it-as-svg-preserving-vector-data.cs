using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the original SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG using default rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = ((SvgImage)svgImage).Size,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                ((SvgImage)svgImage).Save(tempPngPath, pngOptions);

                // Load the rasterized PNG as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
                {
                    // Apply a custom convolution kernel (sharpen example)
                    double[,] kernel = new double[,]
                    {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    // Create a new SVG canvas and draw the filtered raster image onto it
                    var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(rasterImage.Width, rasterImage.Height, 96);
                    graphics.DrawImage(rasterImage, new Point(0, 0));

                    // Finalize SVG and save
                    using (SvgImage finalSvg = graphics.EndRecording())
                    {
                        finalSvg.Save(outputPath);
                    }
                }

                // Clean up temporary PNG file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When a web application needs to enhance the visual sharpness of user‑uploaded SVG logos before embedding them in responsive HTML emails, a developer can rasterize the SVG, apply a custom convolution kernel, and re‑export it as SVG to keep the file size low while preserving vector editability.
 * 2. When generating printable PDFs from SVG diagrams that require a subtle edge‑enhancement filter, a developer can use this code to rasterize the SVG, apply the filter, and save the result back to SVG so downstream tools can still manipulate the vector layers.
 * 3. When an e‑learning platform wants to apply a brand‑specific watermark effect to SVG illustrations without losing their scalability, a developer can rasterize the image, run a custom kernel to embed the watermark, and export the modified content as SVG.
 * 4. When a GIS system needs to preprocess map SVG tiles with a noise‑reduction filter before tiling them for fast client‑side rendering, a developer can employ this code to rasterize each tile, filter it, and save it back as SVG to retain vector metadata.
 * 5. When an automated CI pipeline validates SVG assets by applying a sharpening filter to detect rendering issues, a developer can use this snippet to rasterize the SVG, apply the convolution filter, and re‑export it as SVG for further automated quality checks.
 */