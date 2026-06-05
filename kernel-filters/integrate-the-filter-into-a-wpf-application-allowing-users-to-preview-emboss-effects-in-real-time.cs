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
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output\sample_emboss.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter (used here to simulate emboss effect)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to let users load a PNG or JPEG file in a WPF photo editor and instantly see an emboss effect applied to the raster image before saving.
 * 2. When a desktop application needs to verify that the selected image file exists, create the output folder, and apply a sharpen‑based emboss filter using Aspose.Imaging’s FilterOptions in C#.
 * 3. When a graphics‑intensive WPF tool must convert the filtered raster data back to a PNG with lossless quality for further processing or export.
 * 4. When error handling is required to display friendly messages if the input path is invalid or the filter operation throws an exception during real‑time preview.
 * 5. When a developer integrates Aspose.Imaging’s RasterImage.Filter method into a MVVM command to update the UI binding whenever the user adjusts emboss intensity parameters.
 */