using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/normalized_sharpened.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                double sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double[,] normalizedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalizedKernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                JpegOptions jpegOptions = new JpegOptions();
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to enhance the details of a JPEG photograph while keeping its overall brightness unchanged, they can normalize a 3×3 sharpening kernel and apply it with Aspose.Imaging’s convolution filter.
 * 2. When building an automated image‑processing pipeline that receives raw JPEG uploads and must output consistently brightened, sharpened images for a web gallery, this code provides the necessary C# steps.
 * 3. When creating a desktop C# application that lets users improve the clarity of scanned documents saved as JPEG without causing over‑exposure, the normalized sharpening filter ensures balanced results.
 * 4. When integrating image enhancement into a batch‑processing service that processes thousands of JPEG files on a server, the code demonstrates how to load, filter, and save each image efficiently with Aspose.Imaging.
 * 5. When developing a photo‑editing feature that applies a custom sharpen effect to user‑selected JPEG regions while preserving the original luminance, the example shows how to compute and use a normalized kernel in C#.
 */