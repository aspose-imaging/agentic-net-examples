// HOW-TO: Increase Emboss Edge Strength on PNG Using Custom Convolution Kernel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -4, -2, 0 },
                { -2, 1, 2 },
                { 0, 2, 4 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you need to sharpen the edges of a PNG photograph for a product catalog, you can apply a stronger emboss filter with a custom kernel using Aspose.Imaging in C#.
 * 2. When preparing game textures, developers may enhance surface details by increasing emboss intensity on PNG assets through a convolution filter.
 * 3. When creating stylized thumbnails for a web gallery, you can boost edge definition by adjusting the emboss kernel coefficients in C# code.
 * 4. When preprocessing scanned documents to highlight text outlines, a custom emboss filter can make the characters more pronounced in PNG output.
 * 5. When building an image‑editing tool that offers users adjustable emboss strength, you can implement the feature by modifying the kernel values with Aspose.Imaging’s ConvolutionFilterOptions.
 */
