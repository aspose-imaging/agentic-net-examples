// HOW-TO: Add Black Border to EPS and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.eps";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image epsImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = epsImage.Width;
                int height = epsImage.Height;

                var pngOptions = new PngOptions();

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(epsImage, 0, 0, width, height);

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                    graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

                    canvas.Save(outputPath, pngOptions);
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
 * 1. When you need to convert vector EPS artwork to a raster PNG for web display while preserving a clean white background.
 * 2. When you want to programmatically add a thin black frame around an EPS logo before embedding it in a PDF report.
 * 3. When you must generate lossless PNG thumbnails of EPS files for a product catalog with a consistent border style.
 * 4. When an automated build process requires converting EPS diagrams to PNG images with a surrounding border for documentation consistency.
 * 5. When you are creating a batch script to prepare EPS illustrations for mobile apps, adding a border and saving them as PNG to ensure uniform appearance.
 */
