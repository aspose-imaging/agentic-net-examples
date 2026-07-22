using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Custom kernel emphasizing vertical edges (Sobel vertical)
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer wants to highlight vertical structures such as trees or building edges in a landscape PNG for a photo‑editing application, they can use this code to apply a Sobel vertical convolution filter.
 * 2. When preparing PNG images for a GIS mapping tool that requires enhanced vertical contours to improve feature detection, the code can be used to emphasize vertical edges.
 * 3. When creating a stylized thumbnail gallery where vertical lines should stand out, a developer can apply the custom kernel to each landscape PNG before saving.
 * 4. When building an automated quality‑control pipeline that flags images with weak vertical detail, the code can process PNG files and accentuate vertical edges for analysis.
 * 5. When integrating Aspose.Imaging into a C# desktop app that offers edge‑enhancement filters for photographers, this snippet demonstrates how to apply a vertical Sobel kernel to a landscape PNG image.
 */