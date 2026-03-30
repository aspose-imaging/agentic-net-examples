using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // ---------- PNG processing ----------
        string pngInputPath = @"C:\Images\input.png";
        string pngOutputPath = @"C:\Images\output_filtered.png";

        if (!File.Exists(pngInputPath))
        {
            Console.Error.WriteLine($"File not found: {pngInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

        using (Image image = Image.Load(pngInputPath))
        {
            RasterImage raster = (RasterImage)image;
            // Apply a sharpen filter to the entire image
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
            // Save the filtered image as PNG
            image.Save(pngOutputPath, new PngOptions());
        }

        // ---------- SVG processing ----------
        string svgInputPath = @"C:\Images\input.svg";
        string svgRasterPath = @"C:\Images\svg_raster.png";
        string svgFilteredPath = @"C:\Images\svg_filtered.png";

        if (!File.Exists(svgInputPath))
        {
            Console.Error.WriteLine($"File not found: {svgInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(svgRasterPath));
        Directory.CreateDirectory(Path.GetDirectoryName(svgFilteredPath));

        // Load SVG and rasterize to PNG
        using (Image svgImage = Image.Load(svgInputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(svgRasterPath, pngOptions);
        }

        // Load the rasterized PNG and apply a filter
        using (Image rasterizedImage = Image.Load(svgRasterPath))
        {
            RasterImage raster = (RasterImage)rasterizedImage;
            // Apply a Gaussian blur filter to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            // Save the filtered PNG
            rasterizedImage.Save(svgFilteredPath, new PngOptions());
        }
    }
}