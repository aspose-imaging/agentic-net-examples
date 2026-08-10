// HOW-TO: Apply Vertical Sobel Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply vertical Sobel kernel using convolution filter
                        double[,] sobelKernel = new double[,]
                        {
                            { -1, 0, 1 },
                            { -2, 0, 2 },
                            { -1, 0, 1 }
                        };

                        ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(sobelKernel);
                        raster.Filter(raster.Bounds, convOptions);

                        // Save the processed image
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to extract vertical edges from a vector logo (SVG) to create a high‑contrast PNG for printing or UI icons.
 * 2. When performing automated quality checks on SVG diagrams by detecting edge patterns and saving the results as raster images.
 * 3. When generating edge‑enhanced thumbnails of SVG illustrations for web galleries using C# and Aspose.Imaging.
 * 4. When converting SVG floor plans into PNG maps with vertical edge emphasis for GIS or navigation applications.
 * 5. When building a computer‑vision preprocessing pipeline that rasterizes SVG assets and applies Sobel filtering before further analysis.
 */
