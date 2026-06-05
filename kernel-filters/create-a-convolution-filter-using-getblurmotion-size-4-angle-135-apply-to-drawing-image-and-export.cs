using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "filtered.png");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image with a FileCreateSource (output is bound to the file)
            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Draw on the image
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Black, 5);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 400));

                    // Apply convolution filter (motion blur) to the entire image
                    RasterImage raster = (RasterImage)image;
                    int size = 4;
                    double angle = 135.0;
                    double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(size, angle);
                    var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, convOptions);

                    // Save the image (output file is already bound)
                    image.Save();
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
 * 1. When a developer needs to generate a PNG thumbnail with a stylized motion‑blur rectangle for a web dashboard, they can use this code to draw the shape, apply a 4‑pixel, 135° blur, and save the result.
 * 2. When building automated test data for image‑processing algorithms, a developer can create a synthetic PNG, draw a known geometric object, apply a motion‑blur convolution filter, and export it to verify detection robustness.
 * 3. When creating custom UI icons that require a subtle diagonal blur effect, the code lets a C# developer render the icon on a white canvas, apply Aspose.Imaging’s GetBlurMotion filter, and output a PNG ready for inclusion in the application.
 * 4. When preparing assets for a game’s loading screen where a rectangle should appear as if moving quickly, the developer can use this snippet to draw the rectangle, apply a 4‑pixel, 135° motion blur via ConvolutionFilterOptions, and save the PNG for the engine.
 * 5. When a developer wants to demonstrate the impact of convolution filters in a tutorial or documentation, this example shows how to bind a FileCreateSource, draw graphics, apply a motion‑blur kernel, and export the processed image as a PNG file.
 */