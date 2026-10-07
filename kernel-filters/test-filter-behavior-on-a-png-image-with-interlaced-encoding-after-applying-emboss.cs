// HOW-TO: Apply Emboss Filter to Interlaced PNG and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/interlaced.png";
        string outputPath = "output/embossed.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to enhance the visual depth of an interlaced PNG for a web gallery by applying an emboss effect using C#.
 * 2. When you want to programmatically process PNG assets that use interlacing and output a stylized version without changing the file format.
 * 3. When you are building an automated image pipeline that must apply a convolution filter to PNG files before publishing them.
 * 4. When you need to verify that Aspose.Imaging correctly handles filter operations on interlaced PNG images in a unit test.
 * 5. When you are creating a desktop application that lets users apply artistic effects like emboss to uploaded PNG files while preserving transparency.
 */
