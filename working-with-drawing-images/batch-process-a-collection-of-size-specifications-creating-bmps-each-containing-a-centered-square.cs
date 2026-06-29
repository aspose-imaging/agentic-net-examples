using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            var specs = new List<(int width, int height)>
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            foreach (var spec in specs)
            {
                int width = spec.width;
                int height = spec.height;
                string outputPath = Path.Combine(outputDir, $"image_{width}x{height}.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };

                using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
                {
                    canvas.Save();
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
 * 1. When a developer needs to generate a batch of blank BMP files of various resolutions for testing image‑processing pipelines, they can use this Aspose.Imaging C# code to create the canvases automatically.
 * 2. When an application must export user‑defined canvas sizes as 24‑bit BMP assets for a graphics editor, the code demonstrates how to create and save each image with the appropriate width and height.
 * 3. When a build script has to produce placeholder BMP images for different device screen sizes (e.g., 200×200, 300×150, 400×400) to be bundled with a Windows desktop installer, this snippet shows the required Aspose.Imaging operations.
 * 4. When a developer wants to programmatically generate a set of BMP files for unit tests that verify file‑system handling of image sources, the example illustrates using FileCreateSource and BmpOptions in C#.
 * 5. When an automated reporting tool must create BMP charts of predefined dimensions before drawing graphics, the code provides a quick way to create the empty bitmap canvas that can later be populated.
 */