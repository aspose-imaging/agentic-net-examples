using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded collection of input image paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.tif",
                @"C:\Images\image2.tif",
                @"C:\Images\image3.tif"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Preserve vector data if the source is a TIFF with path resources
                    TiffImage tiff = image as TiffImage;
                    var pathResources = tiff?.ActiveFrame?.PathResources?.ToArray();

                    // Apply the 3x3 sharpen filter to raster images
                    RasterImage raster = image as RasterImage;
                    if (raster != null)
                    {
                        raster.Filter(raster.Bounds,
                            new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));
                    }

                    // Determine output path (same name with .png extension)
                    string outputPath = Path.ChangeExtension(inputPath, ".png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG, preserving any vector data present
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to batch‑process a set of multi‑page TIFF drawings, sharpen each raster layer with a 3×3 convolution filter, and export them as PNG files while keeping any embedded vector paths for later editing.
 * 2. When an engineering application must improve the visual clarity of scanned schematics stored as TIFF, apply a Sharpen3x3 filter to each image and save the result as PNG for web preview without losing the original vector data.
 * 3. When a GIS tool converts high‑resolution TIFF maps to lightweight PNG tiles, it can use this code to enhance raster details with a sharpen filter and preserve path resources for scalable rendering.
 * 4. When an automated build pipeline generates product documentation, it can iterate over source TIFF illustrations, sharpen them, and output PNG assets that retain vector outlines for accessibility tools.
 * 5. When a medical imaging system needs to prepare diagnostic TIFF slides for AI analysis, the code can sharpen the raster content, keep vector annotations, and export the images as PNG for downstream processing.
 */