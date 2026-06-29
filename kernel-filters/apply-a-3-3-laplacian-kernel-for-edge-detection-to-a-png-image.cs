using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));
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
 * 1. When a developer needs to highlight object boundaries in a PNG screenshot for a visual inspection tool, they can apply a 3×3 Laplacian kernel using Aspose.Imaging's convolution filter.
 * 2. When preparing PNG assets for a machine‑learning pipeline that requires edge maps as input, the code can generate sharp edge detection results with a single C# call.
 * 3. When building a desktop application that lets users compare before‑and‑after effects of image sharpening, the Laplacian filter can be used to create the “after” PNG showing detected edges.
 * 4. When automating quality‑control checks on scanned PNG documents, applying the Laplacian kernel helps reveal missing or broken lines that need to be flagged.
 * 5. When creating stylized thumbnails for a web gallery where edge outlines enhance visual appeal, developers can run this C# routine to produce edge‑detected PNG images on the fly.
 */