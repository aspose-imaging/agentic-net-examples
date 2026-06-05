using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.png";
        string outputPath = "output\\edge_detected.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract the outlines of objects in a PNG photograph for CAD preprocessing, they can apply the zero‑sum edge detection kernel using Aspose.Imaging’s convolution filter to produce a black background image with highlighted edges.
 * 2. When building a document‑scanning workflow that must emphasize text boundaries before OCR, the code can run a Laplacian‑style edge detection on scanned PNG pages and save the result for downstream analysis.
 * 3. When creating visual assets for a game where only the silhouette of sprites is required, a developer can use this C# snippet to convert PNG sprites into black‑background edge maps for quick collision‑mask generation.
 * 4. When implementing a quality‑control tool that flags missing or blurred edges in product photos, the edge detection filter applied to PNG files helps automatically highlight problematic regions for inspection.
 * 5. When integrating an image‑processing microservice that needs to return a simplified edge representation of user‑uploaded PNG images, this code demonstrates how to load, filter, and save the processed image using Aspose.Imaging in .NET.
 */