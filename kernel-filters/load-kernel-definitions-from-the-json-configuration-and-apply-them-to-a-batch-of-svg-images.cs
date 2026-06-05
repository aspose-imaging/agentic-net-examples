using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDir = @"C:\InputSvgs";
            string outputDir = @"C:\OutputSvgs";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            // Define kernel definitions manually
            var kernelDefs = new List<KernelDefinition>
            {
                new KernelDefinition { Filter = "gaussian", Radius = 5, Sigma = 1.5 },
                new KernelDefinition { Filter = "sharpen", Radius = 3, Sigma = 0.0 }
            };

            foreach (string svgPath in Directory.GetFiles(inputDir, "*.svg"))
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                using (Image svgImage = Image.Load(svgPath))
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };

                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (Image rasterImg = Image.Load(ms))
                        {
                            var raster = (RasterImage)rasterImg;

                            foreach (var kd in kernelDefs)
                            {
                                if (kd.Filter.Equals("gaussian", StringComparison.OrdinalIgnoreCase))
                                {
                                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(kd.Radius, kd.Sigma));
                                }
                                else if (kd.Filter.Equals("sharpen", StringComparison.OrdinalIgnoreCase))
                                {
                                    raster.Filter(raster.Bounds, new SharpenFilterOptions(kd.Radius, kd.Sigma));
                                }
                            }

                            string fileName = Path.GetFileNameWithoutExtension(svgPath) + ".png";
                            string outputPath = Path.Combine(outputDir, fileName);
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            raster.Save(outputPath, new PngOptions());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private class KernelDefinition
    {
        public string Filter { get; set; }
        public int Radius { get; set; }
        public double Sigma { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically apply Gaussian blur and sharpening kernels defined in a JSON file to a large collection of SVG graphics before converting them to high‑resolution PNGs for web publishing.
 * 2. When an e‑commerce platform must batch‑process product illustration SVGs with custom filter settings stored in configuration to ensure consistent visual quality across all catalog images.
 * 3. When a reporting tool generates SVG charts that must be rasterized and filtered using user‑specified kernel parameters from JSON to embed them as PNGs in PDF documents.
 * 4. When a mobile app backend converts user‑uploaded SVG icons into optimized PNG assets while applying configurable blur or sharpen effects defined in a JSON configuration for brand consistency.
 * 5. When a digital asset management system needs to re‑render archived SVG files with updated filter kernels from a JSON settings file to meet new branding guidelines without manual editing.
 */