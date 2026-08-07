using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When a developer wants to enhance the edge details of product photos in a PNG catalog by applying a custom sharpen kernel derived from an emboss matrix using Aspose.Imaging in C#.
 * 2. When a web application needs to preprocess user‑uploaded PNG avatars to make them appear more crisp by applying a convolution filter that combines emboss and sharpening effects.
 * 3. When an automated build pipeline must generate sharpened PNG assets from original designs for high‑resolution displays, using the ConvolutionFilter.Emboss3x3 option in Aspose.Imaging.
 * 4. When a desktop utility converts scanned PNG documents into clearer images by applying a custom sharpen kernel based on the emboss matrix before saving the result.
 * 5. When a game developer prepares PNG texture maps with enhanced contrast and detail by applying a convolution‑based sharpen filter derived from emboss in a C# tool.
 */