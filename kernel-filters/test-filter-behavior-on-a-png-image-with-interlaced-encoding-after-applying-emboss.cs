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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output_interlaced_emboss.png";

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

                // Apply emboss filter using a predefined convolution kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Configure PNG options for interlaced (progressive) encoding
                PngOptions options = new PngOptions
                {
                    Progressive = true
                };

                // Save the processed image with the specified options
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to generate a progressive (interlaced) PNG with an emboss effect for faster visual loading on web pages, this code demonstrates how to apply the filter and save the image with progressive encoding.
 * 2. When testing image processing pipelines, a developer can use this example to verify that the ConvolutionFilter.Emboss3x3 produces the expected visual result on PNG files before integrating it into larger workflows.
 * 3. When creating stylized product images for an e‑commerce catalog, this snippet shows how to emboss the original PNG and output a progressive PNG that browsers can display incrementally.
 * 4. When performing automated quality assurance on image filters, the code provides a reproducible way to apply an emboss filter and compare the interlaced PNG output against a baseline.
 * 5. When optimizing images for low‑bandwidth environments, a developer can employ this example to apply an emboss effect and save the PNG as a progressive file that progressively renders as data arrives.
 */