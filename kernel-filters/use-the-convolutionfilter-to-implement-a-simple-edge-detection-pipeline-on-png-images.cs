using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_edge.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Edge detection kernel (Laplacian)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply convolution filter for edge detection
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
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
 * 1. When a developer needs to highlight object boundaries in scanned PNG documents to improve OCR accuracy, they can run this edge detection pipeline on the images.
 * 2. When building a security camera system that flags motion by detecting edges in PNG video frames, this code can quickly generate edge maps for analysis.
 * 3. When creating a photo‑editing application that offers a “sketch” filter, developers can apply the Laplacian convolution to PNG photos to produce line‑art style images.
 * 4. When preparing PNG assets for a game’s silhouette rendering, developers can use this pipeline to extract clean edge outlines for collision masks.
 * 5. When automating quality control for printed circuit board images, engineers can run edge detection on PNG scans to identify missing traces or defects.
 */