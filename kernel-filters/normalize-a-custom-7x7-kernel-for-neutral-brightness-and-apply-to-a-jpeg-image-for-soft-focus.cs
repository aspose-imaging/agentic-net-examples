using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)jpegImage;

                // Obtain a 7x7 box blur kernel (already normalized for neutral brightness)
                double[,] kernel = ConvolutionFilter.GetBlurBox(7);

                // Apply the custom convolution filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer wants to add a subtle soft‑focus effect to user‑uploaded JPEG photos in a C# web application, they can use this code to apply a normalized 7×7 blur kernel with Aspose.Imaging.
 * 2. When an e‑commerce platform needs to automatically smooth product images without changing overall brightness, the example shows how to load a JPEG, apply a neutral‑brightness 7×7 convolution filter, and save the result.
 * 3. When a desktop photo‑editing tool requires a fast, repeatable way to create a gentle box‑blur for portrait pictures, this snippet demonstrates the C# operations for loading, filtering, and saving JPEG files using Aspose.Imaging.
 * 4. When a batch‑processing script must prepare a set of JPEG thumbnails with a consistent soft‑focus look while preserving color balance, the code provides the exact steps to normalize the kernel and apply it to each image.
 * 5. When a mobile app backend processes incoming JPEG images and needs to reduce harsh edges before applying further AI analysis, the example shows how to use a 7×7 convolution filter in C# to achieve a neutral‑brightness blur.
 */