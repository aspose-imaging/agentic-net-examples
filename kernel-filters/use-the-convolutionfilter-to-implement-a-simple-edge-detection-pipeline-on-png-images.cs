using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output_edge.png";

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a simple Laplacian edge‑detection kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the convolution filter to the whole image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                // Save the processed image as PNG
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
 * 1. When a developer needs to automatically highlight object boundaries in PNG screenshots for a visual inspection tool, they can use Aspose.Imaging’s ConvolutionFilter to apply a Laplacian edge‑detection kernel.
 * 2. When building a C# batch‑processing pipeline that converts scanned PNG documents into edge‑enhanced images for OCR pre‑processing, the code demonstrates how to load, filter, and save each file.
 * 3. When creating a web service that returns a stylized outline of user‑uploaded PNG graphics, developers can employ the RasterImage.Filter method with a convolution matrix to generate edge‑only previews.
 * 4. When integrating automated quality‑control checks that flag blurry PNG assets in a CI/CD workflow, the edge detection filter can reveal loss of detail by comparing the filtered output to expected edge patterns.
 * 5. When developing an educational desktop app that visualizes basic image‑processing algorithms, this example shows how to implement a simple edge detector on PNG images using C# and Aspose.Imaging.
 */