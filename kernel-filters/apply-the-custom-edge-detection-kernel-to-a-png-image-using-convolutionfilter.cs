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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Custom edge‑detection kernel (3x3)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Create convolution filter options (factor = 1.0, bias = 0)
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
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
 * 1. When a developer needs to highlight object boundaries in PNG screenshots for documentation generation, they can apply the custom edge‑detection kernel with Aspose.Imaging’s ConvolutionFilter.
 * 2. When building a C# desktop application that extracts structural features from scanned engineering drawings saved as PNG, the code can be used to detect edges before further analysis.
 * 3. When creating an automated pipeline that converts medical imaging PNG slices into edge‑enhanced versions for visual inspection, the convolution filter provides a fast C# solution.
 * 4. When developing a web service that generates stylized thumbnails of PNG graphics by emphasizing outlines, the edge‑detection filter can be applied server‑side with Aspose.Imaging.
 * 5. When implementing a quality‑control tool that flags blurry PNG product photos by comparing edge intensity after applying the custom kernel, the code offers a straightforward C# approach.
 */