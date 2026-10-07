// HOW-TO: Apply Gaussian Blur With 5x5 Kernel Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften a photo by applying a subtle Gaussian blur before uploading it to a web gallery.
 * 2. When you want to preprocess images for computer‑vision algorithms by reducing noise with a 5×5 Gaussian filter in a .NET service.
 * 3. When you are building a batch image‑processing tool that automatically blurs JPEG files to meet a design guideline.
 * 4. When you need to create a consistent blur effect across multiple images in a desktop application using Aspose.Imaging.
 * 5. When you are implementing a custom image filter pipeline and require a Gaussian kernel generated programmatically in C#.
 */
