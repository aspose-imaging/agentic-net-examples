using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set up input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var file in files)
            {
                // Process only SVG files
                if (!file.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path for the edge map
                string outputFileName = Path.GetFileNameWithoutExtension(file) + "_edge.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG and rasterize to PNG in memory
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

                    using (var memoryStream = new MemoryStream())
                    {
                        // Rasterize SVG to PNG stream
                        svgImage.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        // Load rasterized image
                        using (Image rasterImageContainer = Image.Load(memoryStream))
                        {
                            var rasterImage = (RasterImage)rasterImageContainer;

                            // Define a custom Sobel horizontal edge detection kernel
                            double[,] kernel = new double[,]
                            {
                                { -1, 0, 1 },
                                { -2, 0, 2 },
                                { -1, 0, 1 }
                            };

                            // Apply convolution filter using the custom kernel
                            var convOptions = new ConvolutionFilterOptions(kernel);
                            rasterImage.Filter(rasterImage.Bounds, convOptions);

                            // Save the edge map
                            rasterImage.Save(outputPath, new PngOptions());
                        }
                    }
                }

                Console.WriteLine($"Processed edge map saved to: {outputPath}");
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
 * 1. When a developer needs to convert a collection of vector icons (SVG) into raster edge‑maps (PNG) for use in a web UI that highlights icon outlines.
 * 2. When a GIS application must extract directional edge information from SVG map layers to feed into a routing algorithm.
 * 3. When an e‑learning platform wants to generate high‑contrast edge images of SVG diagrams for printable worksheets.
 * 4. When a computer‑vision pipeline requires pre‑processing of SVG assets with custom orientation kernels to improve feature detection in downstream ML models.
 * 5. When a branding team automates the creation of stylized edge‑only logos from SVG files for embossing or laser‑cutting workflows.
 */