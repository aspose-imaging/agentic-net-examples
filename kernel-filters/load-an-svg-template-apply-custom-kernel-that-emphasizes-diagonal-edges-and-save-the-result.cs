using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.svg";
            string outputPath = "result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Rasterize SVG to PNG in memory
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImageWrapper = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageWrapper;

                        // Custom kernel emphasizing diagonal edges
                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            {  0, 0, 0 },
                            {  1, 0,-1 }
                        };

                        var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

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
 * 1. When a developer wants to generate a PNG thumbnail from an SVG logo and highlight diagonal edges for a stylized preview.
 * 2. When a web application needs to rasterize user‑uploaded SVG icons and apply a custom convolution filter to emphasize diagonal lines before storing them as PNG files.
 * 3. When an automated reporting tool must convert vector diagrams to raster images and enhance diagonal edges to improve readability in printed PDFs.
 * 4. When a game asset pipeline requires processing SVG textures, applying a diagonal edge detection kernel, and saving the result as PNG for use in shaders.
 * 5. When a document‑generation system has to embed SVG diagrams into PDFs and first rasterize them with a custom kernel to accentuate diagonal features for better visual contrast.
 */