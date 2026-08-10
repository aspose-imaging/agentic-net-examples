// HOW-TO: Apply Diagonal Edge Convolution to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Rasterize SVG to PNG in memory
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        // Custom kernel emphasizing diagonal edges
                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            {  0, 0, 0 },
                            {  1, 0,-1 }
                        };

                        var convOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

                        // Save the filtered raster image
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
 * 1. When you need to convert a vector logo (SVG) into a raster PNG with a diagonal edge‑highlight effect for use in UI icons.
 * 2. When preprocessing SVG diagrams for a computer‑vision pipeline that requires edge‑enhanced raster images.
 * 3. When generating stylized thumbnails of SVG illustrations where diagonal edges should be emphasized for a graphic design effect.
 * 4. When creating printable assets that need a custom convolution filter applied after rasterizing SVG to PNG to improve visual contrast.
 * 5. When automating batch processing of SVG files to produce PNGs with a specific edge‑detect kernel for machine‑learning training data.
 */
