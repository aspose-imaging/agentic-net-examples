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
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                rasterImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to highlight object boundaries in a PNG photograph for a computer‑vision preprocessing step, they can apply this 3×3 edge‑detection kernel using Aspose.Imaging for .NET.
 * 2. When building a document‑scanning application that must emphasize text edges before OCR, the code can run a convolution filter on the scanned image to improve character recognition.
 * 3. When creating a visual‑effects pipeline that requires fast edge extraction from raster images without external libraries, the custom zero‑sum kernel provides a ready‑to‑use C# solution with Aspose.Imaging.
 * 4. When generating thumbnails that need a clear outline of shapes for UI previews, developers can use this filter to convert any input PNG into an edge‑enhanced version before resizing.
 * 5. When troubleshooting image‑processing algorithms and need a reproducible example of a zero‑sum convolution filter in C#, this snippet demonstrates loading, filtering, and saving a PNG with Aspose.Imaging’s FilterOptions.
 */