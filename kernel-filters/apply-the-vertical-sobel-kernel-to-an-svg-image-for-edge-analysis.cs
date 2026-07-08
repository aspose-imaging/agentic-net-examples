using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        try
        {
            // Load SVG and rasterize to PNG (temporary file)
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG and apply vertical Sobel filter
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;

                double[,] sobelKernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to detect vertical edges in a vector logo stored as an SVG and produce a raster PNG highlighting those edges for quality inspection.
 * 2. When an automated build pipeline must convert SVG UI icons to PNG thumbnails and apply a Sobel filter to generate edge‑enhanced previews for documentation.
 * 3. When a web service processes uploaded SVG diagrams, rasterizes them, and runs vertical Sobel edge analysis to identify structural lines before storing the result as a PNG.
 * 4. When a desktop application wants to compare the original SVG artwork with its edge map to verify that scaling or transformations have not introduced artifacts.
 * 5. When a machine‑learning preprocessing step requires extracting vertical edge features from vector graphics by rasterizing SVG files and applying a convolution filter using Aspose.Imaging in C#.
 */