// HOW-TO: Create Custom Elliptical Mask for Watermark Removal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                GraphicsPath mask = new GraphicsPath();

                Figure figure1 = new Figure();
                figure1.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 80)));
                mask.AddFigure(figure1);

                Figure figure2 = new Figure();
                figure2.AddShape(new EllipseShape(new RectangleF(120, 70, 150, 100)));
                mask.AddFigure(figure2);

                Figure figure3 = new Figure();
                figure3.AddShape(new EllipseShape(new RectangleF(200, 30, 80, 120)));
                mask.AddFigure(figure3);

                TeleaWatermarkOptions options = new TeleaWatermarkOptions(mask);

                using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };
                    result.Save(outputPath, pngOptions);
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
 * 1. When you need to erase a multi‑part logo that consists of overlapping ellipses from a PNG image using Aspose.Imaging in C#.
 * 2. When you must generate a custom mask composed of several elliptical regions to protect specific areas while applying the Telea watermark removal algorithm.
 * 3. When an application processes scanned documents that contain irregular, oval‑shaped watermarks and requires precise removal without affecting surrounding pixels.
 * 4. When a batch job has to clean up product photos by defining a complex mask path to target decorative watermark shapes before saving the result as a true‑color PNG with alpha.
 * 5. When you are building a .NET service that dynamically constructs mask figures to remove custom watermark patterns from user‑uploaded images.
 */
