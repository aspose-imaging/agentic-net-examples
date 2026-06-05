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
            string inputPath = "template.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(7, 1.0, 30.0));
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
 * 1. When a developer needs to add a realistic motion blur effect to a PNG UI template before exporting it for a web application, they can use this Aspose.Imaging C# code to load the image, apply a 7‑pixel motion blur at a 30‑degree angle, and save the result.
 * 2. When generating product mock‑ups where a static PNG background must appear as if captured while moving, the code demonstrates how to programmatically apply a motion blur filter using Aspose.Imaging’s MotionWienerFilterOptions in .NET.
 * 3. When automating the creation of animated GIF frames from a series of PNG assets, a developer can first apply a consistent 30‑degree motion blur with size 7 to each frame using this snippet to achieve smooth motion continuity.
 * 4. When preparing marketing banners that require a subtle motion effect on PNG graphics to draw attention, the example shows how to load the template, apply a directional blur, and save the processed image with Aspose.Imaging in C#.
 * 5. When building a server‑side image processing pipeline that receives PNG templates and needs to simulate camera shake by applying a 30‑degree motion blur of radius 7, this code provides a ready‑to‑use implementation with Aspose.Imaging’s raster filter API.
 */