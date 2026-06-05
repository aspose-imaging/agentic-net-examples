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
            string outputPath = "output/output_emboss_interlaced.png";

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

                // Create emboss filter using predefined kernel
                var embossKernel = ConvolutionFilter.Emboss3x3;
                var filterOptions = new ConvolutionFilterOptions(embossKernel);

                // Apply the emboss filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Set PNG save options with interlaced (progressive) encoding
                var saveOptions = new PngOptions
                {
                    Progressive = true
                };

                // Save the processed image
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to add a 3‑x‑3 emboss effect to a PNG file and output it with progressive (interlaced) encoding for quicker incremental loading in browsers, this code provides a ready solution.
 * 2. When building an automated image‑processing pipeline that converts uploaded PNG assets into stylized, interlaced versions for use in responsive web design, the example demonstrates the required C# and Aspose.Imaging steps.
 * 3. When creating a desktop utility that batch‑processes PNG screenshots, applies an emboss filter, and saves them as interlaced PNGs to reduce perceived load time on low‑bandwidth connections, the code shows the essential workflow.
 * 4. When testing the behavior of Aspose.Imaging’s ConvolutionFilter on raster images while preserving PNG interlacing for compatibility with legacy image viewers, this snippet can be used as a reproducible test case.
 * 5. When developing a C# application that generates artistic previews of PNG graphics—applying embossing and saving with the Progressive flag to enable progressive rendering on image galleries—the example illustrates the complete implementation.
 */