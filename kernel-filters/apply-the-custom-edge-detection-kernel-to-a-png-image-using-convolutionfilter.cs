using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

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
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 3);

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
 * 1. When a developer needs to highlight object boundaries in product photos before uploading them to an e‑commerce site, they can run this edge‑detection filter on PNG images to make edges more visible.
 * 2. When building a desktop application that extracts structural features from scanned engineering drawings, the code can be used to apply a Laplacian kernel to PNG scans to emphasize lines and corners.
 * 3. When creating a medical imaging tool that pre‑processes PNG‑formatted X‑ray images for computer‑vision analysis, the convolution filter can detect edges to improve segmentation accuracy.
 * 4. When developing an automated quality‑control system for printed circuit board (PCB) images stored as PNG, the edge‑detection filter helps identify missing traces or solder bridges.
 * 5. When generating stylized thumbnails for a photo‑gallery website, a developer can apply the custom kernel to PNG thumbnails to produce a crisp, outline‑focused preview.
 */