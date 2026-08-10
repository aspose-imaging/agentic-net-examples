// HOW-TO: Apply Emboss 5x5 Filter to JPEG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "face.jpg";
            string outputPath = "face_embossed.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, options);
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
 * 1. When you need to preprocess portrait photos with an emboss effect before feeding them into a face detection algorithm using C# and Aspose.Imaging.
 * 2. When you want to enhance edge details of JPEG images for visual inspection or artistic styling in a .NET application.
 * 3. When you are building a batch pipeline that applies a 5x5 convolution emboss filter to a folder of images before further analysis.
 * 4. When you must ensure the output directory exists and automatically save the embossed version of an input image without manual file handling.
 * 5. When you need to catch and log file‑not‑found or processing errors while applying Aspose.Imaging’s ConvolutionFilter to raster images.
 */
