using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image from disk
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to gain access to filtering operations
                RasterImage raster = (RasterImage)image;

                // Define a vertical edge detection kernel (Sobel operator)
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply the custom convolution filter to the whole image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to load a PNG drawing with Aspose.Imaging, apply a vertical Sobel convolution filter to highlight edges, and save the enhanced image for further analysis.
 * 2. When an image‑processing pipeline must preprocess hand‑drawn sketches by emphasizing vertical lines using a custom kernel before passing the PNG to a machine‑learning model.
 * 3. When a batch job uses C# and Aspose.Imaging to automatically apply a vertical edge‑detection filter to legacy PNG drawings and output the results as new PNG files.
 * 4. When a desktop application wants to sharpen structural outlines in architectural blueprints by casting the image to RasterImage, applying a vertical convolution kernel, and saving the result as PNG.
 * 5. When a web service provides users with a one‑click option to enhance vertical details in uploaded PNG images by applying a custom kernel with Aspose.Imaging’s Filter method.
 */