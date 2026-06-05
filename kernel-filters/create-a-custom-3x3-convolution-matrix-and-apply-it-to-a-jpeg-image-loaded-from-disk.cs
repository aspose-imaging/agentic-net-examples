using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom 3x3 convolution kernel (sharpen example)
                double[,] kernel = new double[3, 3]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Apply the custom convolution filter to the entire image
                var filterOptions = new ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image as JPEG
                var jpegOptions = new JpegOptions();
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
 * 1. When a developer needs to sharpen a product photo before uploading it to an e‑commerce site, they can load the JPEG, apply a custom 3×3 convolution matrix with Aspose.Imaging for .NET, and save the enhanced image.
 * 2. When an automated image‑processing pipeline must improve the clarity of scanned documents stored as JPEG files, the code can be used to apply a sharpen filter via a custom convolution kernel in C#.
 * 3. When a desktop photo‑editing application wants to give users a “sharpen” button that processes the currently opened JPEG using a 3×3 convolution filter from Aspose.Imaging, this snippet provides the core logic.
 * 4. When a batch job needs to preprocess a folder of JPEG images by applying the same custom convolution matrix to each file for better edge definition, the example shows how to load, filter, and save each image in C#.
 * 5. When a developer is building a diagnostic tool that visualizes the effect of different convolution kernels on JPEG images, they can use this code to apply a 3×3 sharpen kernel and compare the output.
 */