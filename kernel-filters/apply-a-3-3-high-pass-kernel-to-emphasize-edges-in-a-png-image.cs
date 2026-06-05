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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_highpass.png";

            // Verify input file exists
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
                // Cast to RasterImage to access filtering
                RasterImage raster = (RasterImage)image;

                // 3×3 high‑pass kernel (edge‑enhancing)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the convolution filter to the whole image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to enhance the edges of a PNG screenshot to improve visual clarity for a UI preview.
 * 2. When an image‑processing pipeline must detect sharp transitions in a scanned document by applying a 3×3 high‑pass convolution filter in C#.
 * 3. When a web service generates thumbnails and wants to emphasize outlines in PNG icons before storing them.
 * 4. When a machine‑learning preprocessing step requires edge‑enhanced PNG images to improve feature extraction accuracy.
 * 5. When a desktop application needs to apply a high‑pass filter to a PNG photograph to create a stylized, edge‑focused effect for user‑editable filters.
 */