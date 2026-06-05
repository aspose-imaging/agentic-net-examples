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
                RasterImage raster = (RasterImage)image;

                // Define a custom 3x3 kernel (example values)
                double[,] customKernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Attempt to apply the custom kernel; fallback to Emboss3x3 on failure
                try
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));
                }
                catch (Exception)
                {
                    // Fallback to built‑in Emboss3x3 kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                }

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a C# application processes user‑uploaded PNG photos and needs to apply a custom sharpening kernel but must guarantee a visible effect even if the kernel is invalid, the code falls back to the built‑in Emboss3x3 filter.
 * 2. When an automated batch job converts scanned documents to PNG and attempts a proprietary edge‑enhancement kernel, the fallback ensures the output still receives a subtle emboss effect if the custom matrix fails validation.
 * 3. When a photo‑editing web service lets developers specify their own 3×3 convolution matrix for PNG images, this pattern provides a safe default Emboss3x3 filter to avoid runtime errors from malformed kernels.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that applies artistic filters to PNG graphics, the fallback guarantees the image is always processed, preventing a blank result when the custom kernel does not meet size or value constraints.
 * 5. When building a C# image‑processing pipeline that validates PNG assets before publishing and wants to replace an invalid custom convolution with a reliable emboss effect, the code automatically switches to the Emboss3x3 filter.
 */