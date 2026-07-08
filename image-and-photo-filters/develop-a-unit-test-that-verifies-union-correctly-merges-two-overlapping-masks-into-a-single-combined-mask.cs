using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand.ImageMasks;

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

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                RectangleMask mask1 = new RectangleMask(20, 20, 100, 100);
                RectangleMask mask2 = new RectangleMask(80, 80, 100, 100);

                ImageBitMask unionMask = mask1.Union(mask2);

                bool test1 = unionMask.IsOpaque(30, 30);
                bool test2 = unionMask.IsOpaque(90, 90);
                bool test3 = unionMask.IsOpaque(150, 150);

                if (test1 && test2 && !test3)
                {
                    Console.WriteLine("Union mask test passed.");
                }
                else
                {
                    Console.WriteLine("Union mask test failed.");
                }

                unionMask.ApplyTo(image);
                image.Save(outputPath, new PngOptions { Source = new FileCreateSource(outputPath, false) });
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
 * 1. When a developer needs to merge overlapping rectangular selections into a single mask for batch PNG image processing using Aspose.Imaging in a C# .NET application.
 * 2. When a developer wants to verify that the Union operation correctly identifies opaque pixels across combined masks before applying the mask to a raster image.
 * 3. When a developer must create a composite mask for selective editing, such as applying filters only to the combined area of two overlapping regions in an image file.
 * 4. When a developer is building automated tests to ensure that ImageBitMask.Union produces the expected mask boundaries for image annotation tools.
 * 5. When a developer requires a reliable way to apply a merged mask to an image and save the result as a PNG using Aspose.Imaging’s ApplyTo and PngOptions features.
 */