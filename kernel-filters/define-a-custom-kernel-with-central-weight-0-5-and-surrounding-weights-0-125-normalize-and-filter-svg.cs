using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outDir ?? ".");

            using (Image svgImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height,
                            BackgroundColor = Color.White
                        }
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { 0.0833333333, 0.0833333333, 0.0833333333 },
                            { 0.0833333333, 0.3333333333, 0.0833333333 },
                            { 0.0833333333, 0.0833333333, 0.0833333333 }
                        };

                        ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
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
 * 1. When a developer needs to convert an SVG logo to a PNG thumbnail and apply a custom 3×3 convolution kernel to subtly blur the edges for smoother web display.
 * 2. When a developer wants to rasterize vector illustrations from SVG files into high‑resolution PNGs while using a normalized kernel to reduce aliasing before embedding the images in a PDF report.
 * 3. When a developer builds an automated pipeline that ingests SVG icons, rasterizes them with a white background, and applies a custom kernel to create a uniform lighting effect for a mobile app UI.
 * 4. When a developer must preprocess SVG diagrams for machine‑learning training by converting them to PNG and applying a normalized convolution filter to standardize pixel intensity across the dataset.
 * 5. When a developer creates a batch job that reads SVG assets, rasterizes them using Aspose.Imaging, and uses a custom 3×3 kernel to enhance edge contrast before uploading the PNGs to a content‑delivery network.
 */