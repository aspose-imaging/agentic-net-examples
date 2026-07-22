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
            string inputPath = @"C:\Images\texture.tga";
            string outputPath = @"C:\Images\texture_sharpened.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter with size 3 and sigma 1.0 (strength three)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save the processed image as BMP
                rasterImage.Save(outputPath);
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
 * 1. When a game developer needs to enhance the visual clarity of a TGA texture before converting it to BMP for use in a legacy engine that only supports BMP assets.
 * 2. When a UI designer wants to programmatically sharpen a high‑resolution TGA sprite by applying a strength‑three filter and save it as BMP for inclusion in a Windows desktop application.
 * 3. When an automated build pipeline processes texture assets, applying a SharpenFilterOptions(3,1.0) to each TGA file and exporting the result as BMP to meet the quality standards of a publishing workflow.
 * 4. When a digital artist exports a TGA map from a 3D modeling tool, then uses C# and Aspose.Imaging to sharpen the map and convert it to BMP for compatibility with a GIS system that requires BMP input.
 * 5. When a software tool needs to batch‑process game textures, loading TGA images, applying a size‑3 sharpen filter to improve edge definition, and saving the output as BMP for legacy hardware rendering.
 */