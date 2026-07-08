using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.drawing";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the drawing image and cast to RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a vertical edge detection kernel (Sobel operator)
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the processed image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a CAD application needs to generate a high‑contrast preview of a drawing file by emphasizing vertical edges before exporting it as a PNG thumbnail.
 * 2. When an engineering portal automatically highlights vertical structural lines in technical drawings using a Sobel kernel and saves the result as a lossless PNG for quick web viewing.
 * 3. When a document management system processes scanned schematics, applies a vertical edge detection filter to improve clarity, and stores the enhanced image as a PNG for archival.
 * 4. When a GIS tool converts vector map drawings to raster, accentuates vertical road boundaries with a custom convolution filter, and outputs the image as a PNG overlay.
 * 5. When a manufacturing quality‑control dashboard extracts vertical edge features from machine‑generated drawing files to create sharp PNG images for defect analysis.
 */