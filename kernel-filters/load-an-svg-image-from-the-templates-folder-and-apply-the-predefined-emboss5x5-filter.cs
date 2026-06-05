using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/input.svg";
            string outputPath = "output/filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImage;

                        // Apply predefined Emboss5x5 filter
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                        // Save the filtered image
                        rasterImage.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a web application uses Aspose.Imaging for .NET to convert SVG icons to PNG thumbnails and apply the Emboss5x5 convolution filter for a subtle 3‑D effect.
 * 2. When an e‑commerce site automates the creation of embossed product badge images by loading SVG templates, rasterizing them with Aspose.Imaging, and saving the result as PNG.
 * 3. When a reporting engine generates PDF reports that embed high‑resolution diagrams, it can load SVG charts, rasterize them with Aspose.Imaging, apply the Emboss5x5 filter, and export the PNG for consistent rendering.
 * 4. When desktop publishing software offers a “Add Emboss” feature, it can use Aspose.Imaging for .NET to load vector logos in SVG, rasterize them, apply the predefined Emboss5x5 filter, and save the stylized PNG.
 * 5. When a game development pipeline processes UI assets, developers can use Aspose.Imaging to load SVG UI elements, rasterize them to PNG, apply the Emboss5x5 convolution filter, and integrate the textured images into the game.
 */