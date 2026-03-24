using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string vectorPath = @"C:\Images\vector.svg";
        string rasterPath = @"C:\Images\raster.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input files exist
        if (!File.Exists(vectorPath))
        {
            Console.Error.WriteLine($"File not found: {vectorPath}");
            return;
        }
        if (!File.Exists(rasterPath))
        {
            Console.Error.WriteLine($"File not found: {rasterPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load vector image to obtain its bounds
        using (Image vectorImage = Image.Load(vectorPath))
        {
            // Define the region based on vector image size
            Rectangle region = new Rectangle(0, 0, vectorImage.Width, vectorImage.Height);

            // Load raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
            {
                // Create PNG options with bound source
                Source src = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions { Source = src };

                // Create canvas matching raster dimensions
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, rasterImage.Width, rasterImage.Height))
                {
                    // Ensure the region fits within the raster image
                    Rectangle intersect = Rectangle.Intersect(region, rasterImage.Bounds);
                    if (intersect.Width > 0 && intersect.Height > 0)
                    {
                        // Copy the defined region from raster to canvas
                        canvas.SaveArgb32Pixels(intersect, rasterImage.LoadArgb32Pixels(intersect));
                    }

                    // Save the resulting image
                    canvas.Save();
                }
            }
        }
    }
}