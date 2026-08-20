// HOW-TO: Apply Emboss3x3 Filter to PNG Image and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.png";
            string outputPath = "Output/processed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
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
 * 1. When you need to add a three‑by‑three emboss effect to user‑uploaded PNG files before storing them on a server using C# and Aspose.Imaging.
 * 2. When you want to process scanned documents in memory, apply an emboss convolution filter for visual emphasis, and write the result directly to an output file without intermediate disk copies.
 * 3. When building a web API that receives an image stream, applies the Emboss3x3 filter, and returns the transformed image to the client in .NET.
 * 4. When creating a batch job that reads images from a folder, enhances their texture with an emboss effect, and saves the processed files to a designated output directory using Aspose.Imaging.
 * 5. When developing a desktop application that previews images with artistic filters, you can load the image, apply the Emboss3x3 convolution, and display or save the result without manual pixel manipulation.
 */
