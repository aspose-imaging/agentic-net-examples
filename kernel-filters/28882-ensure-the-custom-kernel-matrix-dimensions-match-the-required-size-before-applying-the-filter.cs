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
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom kernel (example 3x3 sharpening kernel)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
            };

            // Validate kernel dimensions: must be square and odd-sized
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows != cols || rows % 2 == 0)
            {
                Console.Error.WriteLine("Invalid kernel dimensions. Kernel must be square with odd size.");
                return;
            }

            // Load the image and apply the custom convolution filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply the filter to the entire image bounds
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the result as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to sharpen a PNG logo before embedding it in a web page, they can use this code to apply a 3x3 sharpening kernel and ensure the kernel size is valid.
 * 2. When processing scanned documents in a batch job, a developer can validate the custom edge‑enhancement kernel and apply it to each image to improve OCR accuracy.
 * 3. When building a desktop application that lets users upload photos and apply custom filters, the code can verify the user‑defined kernel dimensions and apply the convolution to the selected PNG file.
 * 4. When automating the preparation of product images for an e‑commerce catalog, a developer can use this snippet to enforce a square odd‑sized kernel and enhance image details before saving the output.
 * 5. When creating a C# service that receives image files via API and needs to apply a custom blur or sharpen effect, the code ensures the kernel matrix matches the required size before processing the image.
 */