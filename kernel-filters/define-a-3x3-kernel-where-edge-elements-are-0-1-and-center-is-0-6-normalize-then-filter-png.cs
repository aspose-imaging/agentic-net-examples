using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Define a 3x3 kernel with edge values 0.1 and center 0.6, then normalize
                double[,] kernel = new double[3, 3];
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] = (x == 1 && y == 1) ? 0.6 : 0.1;
                    }
                }
                double sum = 0.0;
                foreach (double v in kernel) sum += v;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] /= sum; // normalize
                    }
                }

                // Apply the custom convolution filter to the entire image
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the filtered image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to gently smooth a PNG screenshot before embedding it in a PDF report, they can use this Aspose.Imaging C# code to apply a normalized 3×3 convolution filter that reduces high‑frequency noise while preserving details.
 * 2. When preparing product photos for an e‑commerce website, a developer can run this code to apply a light blur to PNG images, helping to hide minor imperfections and create a more consistent visual appearance across the catalog.
 * 3. When building an OCR preprocessing pipeline, a developer can use the custom kernel to slightly denoise scanned PNG documents, improving text recognition accuracy without overly blurring characters.
 * 4. When generating thumbnail previews of user‑uploaded PNG graphics, a developer can apply the normalized convolution filter to reduce aliasing artifacts and produce smoother, more visually appealing small images.
 * 5. When creating a custom image‑filtering feature in a C# desktop application, a developer can employ this code to demonstrate how to define, normalize, and apply a 3×3 kernel with Aspose.Imaging, enabling users to apply a subtle soft‑focus effect to their PNG files.
 */