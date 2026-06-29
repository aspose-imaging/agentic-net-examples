using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "filtered.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Create(new PngOptions { Source = new FileCreateSource(outputPath, false) }, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 400));

                RasterImage raster = (RasterImage)image;
                double[,] kernel = ConvolutionFilter.GetBlurMotion(4, 135);
                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

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
 * 1. When a developer needs to generate a PNG image with a 135° motion‑blur applied via Aspose.Imaging’s ConvolutionFilter.GetBlurMotion to create a stylized preview of a drawn shape.
 * 2. When an application must programmatically draw a rectangle, apply a directional blur using RasterImage.Filter, and export it as a PNG for use in a game UI.
 * 3. When a reporting system wants to embed a blurred diagram in a PDF, using Aspose.Imaging’s convolution filter to add depth to the blue‑bordered graphic.
 * 4. When an automated build process creates placeholder PNG assets with a motion‑blur effect to test layout responsiveness in web applications.
 * 5. When a desktop tool produces custom icons with a subtle 135° motion blur by applying ConvolutionFilterOptions before saving the image.
 */