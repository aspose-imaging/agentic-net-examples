// HOW-TO: Apply Custom Emboss Sharpen Filter to PNG Image with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Obtain the emboss kernel (3x3) and use it as a custom sharpen kernel
                double[,] embossKernel = ConvolutionFilter.Emboss3x3;
                var filterOptions = new ConvolutionFilterOptions(embossKernel);

                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When a developer needs to enhance the edge detail of a PNG graphic by applying a custom sharpen effect derived from an emboss kernel.
 * 2. When an application must programmatically process uploaded PNG files to give them a stylized embossed look without using external image editors.
 * 3. When a batch job has to convert a collection of PNG assets into a more visually striking version for game UI textures using Aspose.Imaging’s convolution filter.
 * 4. When a web service wants to automatically improve the perceived sharpness of user‑submitted PNG avatars while preserving transparency.
 * 5. When a reporting tool requires on‑the‑fly image preprocessing to highlight features in PNG charts before embedding them into PDF documents.
 */
