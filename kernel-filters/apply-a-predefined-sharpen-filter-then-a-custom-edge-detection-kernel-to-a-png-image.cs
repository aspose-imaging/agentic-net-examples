// HOW-TO: Apply Sharpen Then Emboss Edge Detection to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply a Sharpen filter (kernel size 5, sigma 4.0) to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(5, 4.0));

                // Apply a custom edge‑detection kernel (Emboss 3x3) to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
 * 1. When you need to enhance the details of a product photo by sharpening it and then highlight its edges for a catalog generated in a C# application.
 * 2. When preparing PNG assets for a game, you can use this code to sharpen textures and add an emboss effect to give them a more pronounced 3‑D appearance.
 * 3. When building an automated image‑processing pipeline that receives scanned documents as PNG files, applying a sharpen filter followed by edge detection helps improve readability before OCR.
 * 4. When creating visual thumbnails for a web gallery, the code can sharpen the image and apply an emboss kernel to make the thumbnails stand out with a subtle depth effect.
 * 5. When developing a C# desktop tool that lets users batch‑process PNG screenshots, this snippet provides a simple way to apply both sharpening and custom convolution filters in one pass.
 */
