using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Obtain a blur kernel (e.g., box blur of size 5)
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);

                // Normalize the kernel so that its sum equals one
                double sum = 0;
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += kernel[i, j];
                    }
                }
                if (sum != 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                // Apply the normalized convolution filter to the entire image
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as BMP
                var bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to apply a uniform blur to a BMP image for pre‑processing before OCR, they can normalize a box blur kernel and use Aspose.Imaging’s convolution filter in C#.
 * 2. When creating a thumbnail generator that must preserve overall brightness while smoothing edges, normalizing the blur kernel ensures the summed pixel values stay constant across BMP files.
 * 3. When building a medical imaging tool that requires consistent intensity after blurring DICOM‑converted BMP scans, the code guarantees the convolution does not alter the image’s average gray level.
 * 4. When implementing a batch image‑enhancement pipeline that reads BMP files from a folder and applies a subtle blur without darkening the picture, the normalized kernel approach in Aspose.Imaging C# simplifies the process.
 * 5. When developing a game asset pipeline where BMP textures need a gentle blur for anti‑aliasing while keeping color balance, normalizing the kernel before applying the filter prevents unintended brightness shifts.
 */