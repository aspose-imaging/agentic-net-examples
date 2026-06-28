using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Calculate central crop rectangle (half size)
                int cropWidth = raster.Width / 2;
                int cropHeight = raster.Height / 2;
                int x = (raster.Width - cropWidth) / 2;
                int y = (raster.Height - cropHeight) / 2;
                raster.Crop(new Aspose.Imaging.Rectangle(x, y, cropWidth, cropHeight));

                // Prepare SVG save options
                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = new Aspose.Imaging.SizeF(raster.Width, raster.Height);
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the processed image as SVG
                raster.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert a high‑resolution PNG photograph into a lightweight SVG for responsive web design while applying a soft Gaussian blur and focusing on the central area.
 * 2. When an application must generate thumbnail previews of scanned documents by blurring noise, cropping the middle portion, and saving the result as scalable SVG for PDF embedding.
 * 3. When a graphics pipeline requires preprocessing of raster assets—applying a Gaussian blur to reduce aliasing, extracting the core region, and exporting to SVG for use in vector‑based UI components.
 * 4. When an e‑commerce site wants to display product images with a subtle blur effect and a centered crop, then store them as SVG to ensure crisp scaling on high‑DPI screens.
 * 5. When a reporting tool needs to transform PNG charts into SVG charts, smoothing edges with a Gaussian blur, cropping to the chart’s central area, and preserving scalability for print layouts.
 */