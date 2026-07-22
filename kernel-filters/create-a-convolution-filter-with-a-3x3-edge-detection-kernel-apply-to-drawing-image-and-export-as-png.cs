// HOW-TO: Apply 3x3 Edge Detection Convolution Filter to PNG Canvas in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path (hardcoded)
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create PNG options with a bound output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new PNG image canvas
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Draw on the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Black, 5), new Rectangle(50, 50, 300, 300));

                // Apply a 3x3 edge detection convolution filter
                RasterImage raster = (RasterImage)image;
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, convOptions);

                // Save the final image (output file already bound)
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
 * 1. When you need to generate a PNG image with custom graphics and highlight edges for visual analysis.
 * 2. When you want to programmatically draw shapes and then apply an edge detection filter to emphasize outlines.
 * 3. When you must create a PNG file on the fly without writing an intermediate bitmap, using Aspose.Imaging in C#.
 * 4. When you need to process a raster image in memory and export the filtered result directly to disk.
 * 5. When you are building a server‑side service that adds edge detection to user‑uploaded drawings before saving them as PNG.
 */
