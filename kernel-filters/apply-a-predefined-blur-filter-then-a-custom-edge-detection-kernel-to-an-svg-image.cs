using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply predefined Gaussian blur filter
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Apply custom edge‑detection kernel
                        double[,] edgeKernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                        // Save the final image
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
 * 1. When a developer needs to generate a stylized thumbnail of an SVG icon by softening details with a Gaussian blur before highlighting its outlines with an edge‑detection kernel for a web gallery.
 * 2. When a C# application must preprocess vector graphics for OCR by converting SVG to raster PNG, applying blur to reduce noise, and then extracting sharp edges to improve character segmentation.
 * 3. When a reporting tool requires converting scalable diagrams into printable PNGs with a subtle blur effect followed by edge enhancement to make lines stand out on high‑resolution PDFs.
 * 4. When a game asset pipeline automates the creation of sprite sheets from SVG assets, using a blur filter to create a glow effect and an edge‑detection filter to generate a contrasting outline for UI overlays.
 * 5. When a machine‑learning dataset needs labeled edge maps from vector illustrations, developers can rasterize the SVG, blur to smooth gradients, and apply a custom kernel to produce clear edge images for training segmentation models.
 */