using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image inputImage = Image.Load(inputPath))
            {
                RasterImage raster = inputImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Input image is not a raster image.");
                    return;
                }

                Graphics graphics = new Graphics(raster);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new Rectangle(60, 60, 180, 130));
                }

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to programmatically add a blue border and a red fill to a PNG image for creating branded marketing assets, they can use this code to draw and fill rectangles while ensuring Graphics and Image objects are disposed.
 * 2. When an application must generate annotated screenshots by overlaying shapes on user‑uploaded PNG files, this example shows how to load, draw, and save the image without memory leaks.
 * 3. When a batch‑processing tool has to watermark product photos with a colored rectangle before publishing them to a website, the code demonstrates safe resource handling with using statements.
 * 4. When a desktop utility needs to convert raw PNG files into a new version that includes a white background and highlighted area for printing, this snippet provides the necessary drawing and saving steps.
 * 5. When a C# service processes incoming image streams and must add visual markers such as rectangles for quality‑control checks, the example illustrates proper disposal of Graphics and Image objects to avoid out‑of‑memory errors.
 */