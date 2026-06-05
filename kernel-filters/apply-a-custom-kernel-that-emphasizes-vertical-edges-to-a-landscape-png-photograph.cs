using System;
using System.IO;
using Aspose.Imaging;

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

                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

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
 * 1. When a developer wants to enhance the vertical outlines of a landscape photograph stored as a PNG file before publishing it on a website, they can apply this vertical edge convolution filter using Aspose.Imaging for .NET.
 * 2. When building an automated image preprocessing pipeline that prepares raw PNG scenery shots for computer‑vision analysis, the code can be used to emphasize vertical edges to improve feature detection.
 * 3. When creating a desktop application that lets users sharpen the silhouette of trees and buildings in a PNG panorama, the vertical edge kernel can be applied with C# and Aspose.Imaging to produce a clearer visual effect.
 * 4. When generating printable map overlays where vertical contours such as cliffs or road edges need to be highlighted, developers can run this filter on the PNG raster to accentuate those lines.
 * 5. When integrating a batch‑processing tool that converts a folder of landscape PNG images into edge‑enhanced versions for artistic filters, the code provides a simple way to apply the vertical edge convolution across each image.
 */