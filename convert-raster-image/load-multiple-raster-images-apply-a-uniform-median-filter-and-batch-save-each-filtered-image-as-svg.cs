using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input image paths
            string[] inputPaths = new[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.jpg",
                @"C:\Images\image3.bmp"
            };

            // Size of the median filter kernel
            int medianFilterSize = 5;

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output SVG path (same folder, same name, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(medianFilterSize));

                    // Prepare SVG save options with rasterization settings
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = rasterImage.Size
                    };

                    SvgOptions svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the filtered image as SVG
                    image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to batch‑process a collection of PNG, JPEG, or BMP photos, remove noise with a uniform median filter, and export each cleaned image as a scalable SVG for responsive web design.
 * 2. When an application must automatically enhance scanned documents by applying a 5‑pixel median filter to reduce speckles before converting them to SVG vectors for searchable PDFs.
 * 3. When a medical imaging workflow requires denoising multiple raster X‑ray images in C# using Aspose.Imaging and saving the results as SVG files for loss‑less archival and easy annotation.
 * 4. When a graphics pipeline has to convert legacy product catalog images into SVG format while preserving dimensions, applying a consistent median filter to ensure uniform visual quality across all assets.
 * 5. When a developer builds a command‑line tool that reads raster images from a folder, applies the same median filter to each image to smooth edges, and batch‑saves them as SVG files for use in vector‑based reporting dashboards.
 */