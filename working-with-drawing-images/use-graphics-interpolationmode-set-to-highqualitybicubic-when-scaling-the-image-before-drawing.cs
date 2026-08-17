// HOW-TO: Resize JPEG to PNG with High Quality Bicubic Scaling in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = sourceImage.Width * 2;
                int newHeight = sourceImage.Height * 2;

                PngOptions pngOptions = new PngOptions();

                using (Image canvas = Image.Create(pngOptions, newWidth, newHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, newWidth, newHeight));

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
 * 1. When you need to double the dimensions of a JPEG photo while preserving detail and save the result as a PNG for web use.
 * 2. When you want to generate high‑resolution thumbnails from user‑uploaded JPEGs and store them in lossless PNG format.
 * 3. When you are preparing product images for print by upscaling JPEGs with bicubic interpolation to avoid pixelation before converting to PNG.
 * 4. When you need to convert legacy JPEG assets to PNG with smoother scaling for inclusion in a mobile app’s UI.
 * 5. When you are building an image processing pipeline that requires consistent high‑quality resizing of JPEGs before applying further graphics operations.
 */
