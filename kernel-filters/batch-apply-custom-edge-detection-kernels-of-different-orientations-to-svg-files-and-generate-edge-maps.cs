using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);

                using (Image vectorImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = vectorImage.Size
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                    using (var ms = new MemoryStream())
                    {
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            var kernels = new (string name, double[,] kernel)[]
                            {
                                ("Horizontal", new double[,] {
                                    { -1, 0, 1 },
                                    { -2, 0, 2 },
                                    { -1, 0, 1 }
                                }),
                                ("Vertical", new double[,] {
                                    { -1, -2, -1 },
                                    {  0,  0,  0 },
                                    {  1,  2,  1 }
                                }),
                                ("Diagonal1", new double[,] {
                                    { -2, -1, 0 },
                                    { -1,  0, 1 },
                                    {  0,  1, 2 }
                                }),
                                ("Diagonal2", new double[,] {
                                    { 0,  1,  2 },
                                    { -1, 0,  1 },
                                    { -2, -1, 0 }
                                })
                            };

                            foreach (var (orientation, kernel) in kernels)
                            {
                                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                                string outputPath = Path.Combine(outputDirectory, $"{fileName}_{orientation}.png");
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                raster.Save(outputPath);
                            }
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
 * 1. When a developer needs to automatically convert a collection of SVG icons into PNG edge‑map images for use in a web UI that highlights vector shapes.
 * 2. When a GIS application must generate orientation‑specific edge maps from SVG map layers to improve feature detection in downstream analysis.
 * 3. When an e‑learning platform wants to batch process SVG diagrams into high‑contrast edge images for printable worksheets without manual rasterization.
 * 4. When a computer‑vision pipeline requires pre‑rasterized SVG assets with custom Sobel‑like kernels applied to detect vertical, horizontal, and diagonal edges before model training.
 * 5. When a branding team needs to create stylized outline versions of SVG logos in PNG format by applying multiple directional edge‑detection filters in a single automated run.
 */