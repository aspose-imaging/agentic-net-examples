// HOW-TO: Resize PNG to Half Size and Apply Emboss Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight);

                image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate smaller, stylized thumbnails of PNG photos for a web gallery, you can resize them and add an emboss effect with Aspose.Imaging in C#.
 * 2. When preparing product images for an e‑commerce site, you may want to halve the resolution to reduce load time and give a subtle 3‑D look by applying the Emboss3x3 filter.
 * 3. When creating printable assets that require a consistent size and artistic edge, developers can programmatically shrink PNG files and emboss them before saving.
 * 4. When automating batch processing of user‑uploaded PNGs, you can use this code to standardize dimensions and enhance visual depth without manual editing.
 * 5. When building a C# desktop application that previews images with a classic embossed style, the routine resizes the image and applies the filter in real time.
 */
