using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

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

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply a blur box filter (kernel size 5)
                var blurKernel = ConvolutionFilter.GetBlurBox(5);
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(blurKernel));

                // Apply an emboss filter (3x3 emboss kernel)
                var embossKernel = ConvolutionFilter.Emboss3x3;
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(embossKernel));

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer wants to create a stylized product photo by softening details with a blur box, adding a textured emboss effect, and then sharpening edges to make the JPEG image pop for an e‑commerce website.
 * 2. When a developer needs to preprocess scanned JPEG documents to reduce noise, highlight raised text with an emboss filter, and enhance readability with a sharpen filter before performing OCR.
 * 3. When a developer is building a photo‑filter app that applies a combined blur‑box, emboss, and sharpen pipeline to user‑uploaded JPEGs for artistic social‑media posts.
 * 4. When a developer must generate preview thumbnails that simulate a printed brochure look by smoothing, embossing relief, and sharpening to emphasize design elements in a JPEG file.
 * 5. When a developer is automating batch processing of JPEG assets for a game UI, applying a blur to soften the background, emboss for depth, and sharpen to keep UI icons crisp.
 */