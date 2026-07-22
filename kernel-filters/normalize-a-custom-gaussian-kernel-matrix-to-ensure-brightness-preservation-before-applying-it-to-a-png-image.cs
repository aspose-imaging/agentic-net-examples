using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom Gaussian kernel (example 3x3)
            double[,] kernel = new double[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            };

            // Compute the sum of all kernel elements
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    sum += kernel[i, j];
                }
            }

            // Normalize the kernel to preserve brightness (sum should be 1)
            double[,] normalized = new double[kernel.GetLength(0), kernel.GetLength(1)];
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    normalized[i, j] = kernel[i, j] / sum;
                }
            }

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom normalized convolution filter
                var filterOptions = new ConvolutionFilterOptions(normalized);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to apply a custom blur effect to a PNG screenshot while keeping the overall brightness unchanged, they can normalize a Gaussian kernel and use Aspose.Imaging’s ConvolutionFilterOptions.
 * 2. When processing medical imaging PNG files that require a precise smoothing filter without altering pixel intensity, normalizing the kernel ensures diagnostic brightness is preserved.
 * 3. When building an automated image‑processing pipeline in C# that sharpens PNG icons using a custom Gaussian matrix, normalizing the kernel prevents the icons from becoming too dark or too light.
 * 4. When creating a photo‑editing tool that lets users define their own Gaussian blur strength for PNG backgrounds, the code normalizes the matrix so the edited image retains its original luminance.
 * 5. When performing batch conversion of PNG assets with a tailored edge‑softening filter in a .NET application, normalizing the kernel guarantees consistent brightness across all output files.
 */