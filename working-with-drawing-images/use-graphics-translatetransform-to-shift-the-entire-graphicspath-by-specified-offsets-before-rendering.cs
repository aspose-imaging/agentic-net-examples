// HOW-TO: Shift a GraphicsPath and Draw Rectangle on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                int width = inputImage.Width;
                int height = inputImage.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image outputImage = Image.Create(pngOptions, width, height))
                {
                    RasterImage outputRaster = (RasterImage)outputImage;

                    int[] pixels = inputImage.LoadArgb32Pixels(new Rectangle(0, 0, inputImage.Width, inputImage.Height));
                    outputRaster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                    Graphics graphics = new Graphics(outputImage);

                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    RectangleShape rectShape = new RectangleShape(new RectangleF(0, 0, 100, 50));
                    figure.AddShape(rectShape);
                    path.AddFigure(figure);

                    int offsetX = 50;
                    int offsetY = 30;
                    graphics.TranslateTransform(offsetX, offsetY);

                    Pen pen = new Pen(Color.Blue, 3);
                    graphics.DrawPath(pen, path);

                    outputImage.Save();
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
 * 1. When you need to overlay a blue rectangle at a precise X/Y offset on an existing PNG image for watermarking or highlighting using Aspose.Imaging in C#.
 * 2. When you want to reposition vector shapes before rendering them onto a raster canvas to create dynamic layouts or UI elements in a PNG file.
 * 3. When you must copy the pixel data of a source PNG and then draw a translated shape on top without changing the original image size or resolution.
 * 4. When you are generating thumbnails that include a shifted annotation or border drawn with a custom pen and saved as PNG.
 * 5. When you require programmatic control of shape placement in automated report graphics, such as adding offset rectangles to charts exported as PNG files.
 */
