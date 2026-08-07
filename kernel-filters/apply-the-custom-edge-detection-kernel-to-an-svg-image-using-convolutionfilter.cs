using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        try
        {
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

            using (Image img = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)img;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 3);

                raster.Filter(raster.Bounds, convOptions);

                raster.Save(outputPath);
            }

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
 * 1. When a developer needs to generate high‑contrast outlines of vector logos stored as SVG for use in print‑ready PNG assets, they can rasterize the SVG and apply a custom edge‑detection convolution filter.
 * 2. When an e‑learning platform wants to highlight diagram boundaries in SVG illustrations before converting them to PNG thumbnails, the code provides a C# solution that rasterizes and sharpens edges with a 3×3 kernel.
 * 3. When a web service must automatically detect and emphasize edges in user‑uploaded SVG icons to create stylized PNG badges, the Aspose.Imaging ConvolutionFilter can be used to process the images server‑side.
 * 4. When a GIS application requires extracting contour lines from SVG map overlays and saving them as PNG layers, applying the custom edge‑detection kernel after rasterization simplifies the workflow.
 * 5. When a mobile app needs to preprocess SVG assets for computer‑vision models by converting them to PNG and enhancing edge features, this C# code demonstrates the necessary rasterization and filtering steps.
 */