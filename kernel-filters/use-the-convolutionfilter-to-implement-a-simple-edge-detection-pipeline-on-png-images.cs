// HOW-TO: Apply Edge Detection to PNG Using Aspose.Imaging Convolution Filter in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/edge_detected.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply a simple edge detection using the emboss kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
                PngOptions pngOptions = new PngOptions();
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
 * 1. When you need to highlight object outlines in product photos before uploading them to an e‑commerce site.
 * 2. When you want to preprocess scanned documents to emphasize text edges for OCR accuracy.
 * 3. When you are building a desktop tool that converts raw PNG screenshots into stylized line‑art for presentations.
 * 4. When you must generate edge‑detected thumbnails for a gallery that helps users spot visual differences quickly.
 * 5. When you are automating a batch job that applies emboss‑style edge detection to PNG assets for a game’s UI effects.
 */
