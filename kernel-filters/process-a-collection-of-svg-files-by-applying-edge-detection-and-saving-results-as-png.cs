using System;
using System.IO;
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    // Prepare PNG options with vector rasterization
                    PngOptions pngOptions = new PngOptions();
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    // Rasterize SVG to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Sobel edge detection kernel
                            double[,] kernel = new double[,]
                            {
                                { -1, 0, 1 },
                                { -2, 0, 2 },
                                { -1, 0, 1 }
                            };
                            var filterOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            // Save the processed image as PNG
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
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a library of vector icons (SVG) into raster PNG thumbnails with edge detection for a web UI, they can use this code.
 * 2. When an e‑commerce platform wants to generate high‑contrast product outline images from SVG designs for marketing materials, the snippet automates the rasterization and edge‑filtering process.
 * 3. When a GIS application must prepare map symbols by extracting their edges from SVG files and storing them as PNG assets for faster rendering on mobile devices, this code provides a C# solution.
 * 4. When a documentation generator requires edge‑enhanced PNG screenshots of SVG diagrams to improve readability in PDF reports, the example processes the entire folder automatically.
 * 5. When a CI/CD pipeline needs to validate visual changes by comparing edge‑detected PNG outputs of SVG assets across builds, the program offers a repeatable batch conversion step.
 */