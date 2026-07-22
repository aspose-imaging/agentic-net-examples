using System;
using System.IO;
using Aspose.Imaging;
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
 * 1. When a developer needs to apply a Sobel‑style convolution filter to a PNG photograph to highlight object boundaries for medical imaging analysis.
 * 2. When an automated quality‑control system must run a 3×3 edge‑detection kernel on scanned product label PNG files to detect scratches or defects.
 * 3. When a computer‑vision pipeline processes satellite PNG imagery and uses the custom zero‑sum kernel to extract road edges before classification.
 * 4. When a security application applies the convolution filter to PNG frames from surveillance video to emphasize motion silhouettes for further analysis.
 * 5. When a graphic‑design tool offers an edge‑enhancement feature that runs the custom kernel on user‑uploaded PNG images to create stylized line‑art.
 */