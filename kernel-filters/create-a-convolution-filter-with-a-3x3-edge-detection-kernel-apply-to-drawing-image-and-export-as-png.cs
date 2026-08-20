// HOW-TO: Apply Edge Detection Convolution Filter to Drawn Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(100, 100, 300, 300));
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(100, 100), new Point(400, 400));

                RasterImage raster = (RasterImage)image;
                double[,] kernel = new double[3, 3]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                image.Save();
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
 * 1. When you need to programmatically generate a diagram, highlight its edges, and export it as a high‑quality PNG for web display.
 * 2. When you want to add custom edge‑detection processing to dynamically drawn shapes in a C# application without using external image‑processing libraries.
 * 3. When you must create a raster image, draw geometric primitives, apply a 3×3 convolution kernel, and save the result for further analysis or reporting.
 * 4. When you are building a preview generator that emphasizes outlines of vector drawings by applying a convolution filter before saving to PNG.
 * 5. When you require an automated way to produce PNG assets with enhanced edge contrast for machine‑vision or OCR preprocessing in .NET.
 */
