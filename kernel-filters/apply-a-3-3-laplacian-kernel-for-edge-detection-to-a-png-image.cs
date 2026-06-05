using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] laplacianKernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(laplacianKernel));

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
 * 1. When a developer needs to highlight edges in a PNG photograph for computer‑vision preprocessing, they can apply a 3×3 Laplacian kernel using Aspose.Imaging in C#.
 * 2. When building a .NET desktop application that converts scanned PNG documents into line‑art, the code can perform edge detection to improve contrast and readability.
 * 3. When creating an automated quality‑control pipeline that flags defects in product images, applying the Laplacian filter to PNG files helps detect sharp transitions indicating scratches or dents.
 * 4. When developing a web service that returns stylized PNG thumbnails with emphasized outlines, the C# routine loads the image, runs the convolution filter, and saves the edge‑detected result for fast delivery.
 * 5. When integrating image analysis into a medical imaging tool that requires edge detection on PNG scans, the sample shows how to perform the operation with Aspose.Imaging’s RasterImage class.
 */