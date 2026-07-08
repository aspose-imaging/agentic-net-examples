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

            // Validate input file existence
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
                RasterImage rasterImage = (RasterImage)image;

                // Define a 3×3 high‑pass kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the convolution filter with the custom kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                rasterImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to enhance the outlines of objects in a PNG screenshot for a visual inspection tool, they can apply a 3×3 high‑pass kernel with Aspose.Imaging to emphasize edges.
 * 2. When preparing product photos for an e‑commerce site and wanting to highlight product contours without changing the file format, the code can be used to apply edge‑enhancement to PNG images.
 * 3. When building a document‑generation pipeline that adds a subtle edge‑sharpening effect to embedded PNG diagrams to improve readability in printed PDFs, this filter can be applied.
 * 4. When creating a custom thumbnail generator that accentuates edges in PNG icons to make them stand out in a UI gallery, the high‑pass convolution filter provides the needed processing.
 * 5. When developing an automated quality‑control system that detects missing or blurred edges in PNG scans of printed circuit boards, the code can be used to emphasize edges before further analysis.
 */