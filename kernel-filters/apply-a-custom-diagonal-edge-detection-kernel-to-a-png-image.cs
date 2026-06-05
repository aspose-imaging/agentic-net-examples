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
        string outputPath = "output\\output.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a diagonal edge‑detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    {  0, 0, 0 },
                    {  1, 0,-1 }
                };

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
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
 * 1. When a developer uses Aspose.Imaging for .NET to highlight diagonal edges in a PNG screenshot for visual inspection.
 * 2. When an image‑processing workflow needs to apply a custom convolution kernel to PNG scans to enhance diagonal lines before OCR.
 * 3. When a game‑asset pipeline uses C# and Aspose.Imaging to apply a diagonal edge‑detection filter to PNG textures prior to mipmap generation.
 * 4. When a medical‑imaging application processes PNG X‑ray files with a custom diagonal edge‑detection filter to accentuate bone structures.
 * 5. When a web service creates stylized PNG thumbnails by applying a diagonal edge‑detection convolution filter using Aspose.Imaging in C#.
 */