using System;
using System.IO;
using Aspose.Imaging;
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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 0.8
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 0.8));

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to clean up noise in a low‑light PNG photograph before displaying it in a web gallery, they can use this code to apply a Gaussian blur with sigma 0.8.
 * 2. When an automated image‑processing pipeline must improve the visual quality of user‑uploaded PNG files by reducing grain without losing detail, the code provides a C# solution using Aspose.Imaging’s GaussianBlurFilterOptions.
 * 3. When a desktop application that imports PNG screenshots from night‑time camera feeds requires quick denoising, the example shows how to load, filter, and save the image with a 0.8 sigma blur.
 * 4. When a batch‑processing script needs to ensure all PNG assets in a folder have consistent noise reduction for printing, this snippet demonstrates the necessary file‑existence checks and directory creation in C#.
 * 5. When a developer is building a photo‑editing tool that offers a “low‑light enhancement” feature, the code illustrates how to apply a Gaussian blur filter to the raster image and overwrite the original PNG.
 */