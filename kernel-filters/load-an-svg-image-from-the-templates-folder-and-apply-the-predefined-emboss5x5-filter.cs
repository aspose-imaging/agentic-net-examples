using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            string tempPng = Path.Combine(Path.GetTempPath(), "temp_svg.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPng, pngOptions);
            }

            // Load the rasterized PNG, apply Emboss5x5 filter, and save the result
            using (Image rasterImageContainer = Image.Load(tempPng))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                double[,] embossKernel = ConvolutionFilter.Emboss5x5;
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(embossKernel));

                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPng))
            {
                File.Delete(tempPng);
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
 * 1. When a web application needs to generate embossed preview thumbnails from user‑uploaded SVG icons, this C# code can rasterize the SVG to PNG and apply the Emboss5x5 filter before serving the image.
 * 2. When an e‑commerce platform wants to add a subtle 3‑D effect to product vector logos for marketing banners, the code converts the SVG logos to raster images and embosses them automatically.
 * 3. When a desktop publishing tool requires converting scalable SVG illustrations into high‑resolution PNG assets with a textured look for print layouts, the script performs the rasterization and emboss filtering in one workflow.
 * 4. When a game developer creates UI assets from SVG assets and needs a quick way to generate embossed button graphics for UI skins, this snippet loads the SVG, rasterizes it, and applies the Emboss5x5 filter.
 * 5. When an automated reporting system must embed stylized SVG diagrams into PDF reports as PNG images with an embossed appearance, the code provides the necessary SVG‑to‑PNG conversion and emboss effect in C#.
 */