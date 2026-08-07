using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.svg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPng = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

            // Rasterize SVG to temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                svgImage.Save(tempPng, pngOptions);
            }

            // Apply Emboss5x5 filter to the rasterized PNG
            using (Image img = Image.Load(tempPng))
            {
                var raster = (RasterImage)img;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a vector‑based SVG icon into a raster PNG while preserving its original colors but wants the edges to appear sharper, they can use this code to rasterize and apply an Emboss5x5 filter.
 * 2. When building a web UI that displays SVG logos as PNG thumbnails with enhanced line definition for low‑resolution screens, the code provides a C# solution that rasterizes the SVG and embosses the result without changing hue.
 * 3. When generating asset bundles for mobile apps where SVG icons must be pre‑processed into PNGs with a subtle embossed effect to improve visual contrast, this snippet automates the rasterization and convolution filter steps.
 * 4. When creating printable PDFs that embed PNG versions of SVG icons with clearer outlines, developers can employ this routine to rasterize the SVG, apply the Emboss5x5 filter, and save the output while keeping the original color palette intact.
 * 5. When a design pipeline requires batch processing of stylized SVG symbols into PNGs with enhanced edge detail for UI mockups, the code demonstrates how to use Aspose.Imaging’s VectorRasterizationOptions and ConvolutionFilterOptions in C#.
 */