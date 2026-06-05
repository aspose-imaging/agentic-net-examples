using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Obtain the emboss kernel (3x3) and use it as a custom sharpen kernel
                double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
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
 * 1. When a developer needs to enhance the edge definition of product photos in an e‑commerce catalog by loading PNG files with Aspose.Imaging and applying a custom sharpen filter derived from an emboss kernel before publishing them online.
 * 2. When a desktop application must automatically improve the visual clarity of scanned engineering drawings saved as PNG by using Aspose.Imaging’s convolution filter with an emboss‑based kernel to highlight fine lines.
 * 3. When a batch‑processing service for a digital asset management system has to sharpen PNG screenshots using Aspose.Imaging’s custom filter options to make on‑screen text more readable in documentation.
 * 4. When a game‑development tool requires preprocessing of PNG texture assets with Aspose.Imaging to accentuate surface details by applying a custom sharpen kernel derived from the emboss matrix.
 * 5. When a medical‑imaging workflow needs to emphasize subtle features in PNG X‑ray images by applying Aspose.Imaging’s convolution filter that sharpens while preserving the original contrast.
 */