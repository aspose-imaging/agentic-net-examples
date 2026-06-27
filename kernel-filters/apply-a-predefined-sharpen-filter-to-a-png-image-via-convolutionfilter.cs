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
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a developer needs to enhance the visual clarity of product photos stored as PNG files before uploading them to an e‑commerce website, they can use this code to apply a sharpen filter with a 5×5 kernel and sigma 4.0.
 * 2. When an automated image‑processing pipeline must improve the readability of scanned PNG diagrams for a documentation portal, the code can be integrated to sharpen edges without converting the image format.
 * 3. When a desktop application written in C# generates PNG screenshots of UI components and wants to make fine details more pronounced for user testing, the SharpenFilterOptions can be applied directly to the RasterImage.
 * 4. When a batch job processes a folder of PNG assets for a mobile game and needs to boost texture sharpness while preserving transparency, this snippet demonstrates how to load, filter, and save each image using Aspose.Imaging.
 * 5. When a developer builds a server‑side service that receives PNG uploads and must automatically enhance image quality before storing them in a cloud repository, the code shows how to verify the file, apply a convolution sharpen filter, and save the result.
 */