using System;
using System.IO;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

                // Apply predefined Sharpen filter (kernel size 5, sigma 4.0)
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Define a custom edge‑detection kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the custom convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to enhance the details of a PNG photograph for a product catalog by first sharpening the image and then highlighting edges for a crisp visual presentation.
 * 2. When an application must preprocess scanned PNG documents to improve readability, applying a Sharpen filter followed by an edge‑detection kernel to make text and line art stand out.
 * 3. When a game‑engine toolchain requires automated preparation of PNG textures, using the code to sharpen textures and extract edge outlines for normal‑map generation.
 * 4. When a medical‑imaging system processes PNG scans and wants to emphasize anatomical boundaries, the developer can apply the predefined Sharpen filter and then a custom convolution edge detector.
 * 5. When a web‑based image‑upload service wants to automatically improve user‑submitted PNG avatars by sharpening facial features and extracting edge contours for stylized thumbnails.
 */