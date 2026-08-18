// HOW-TO: Add Custom Red Thumbnail to JPEG JFIF Segment Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                PngOptions thumbOptions = new PngOptions();
                thumbOptions.Source = new StreamSource(new MemoryStream(), false);

                using (RasterImage thumb = (RasterImage)Image.Create(thumbOptions, 100, 100))
                {
                    Graphics graphics = new Graphics(thumb);
                    SolidBrush brush = new SolidBrush(Color.Red);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    jpegImage.Jfif = new JFIFData();
                    jpegImage.Jfif.Thumbnail = thumb;

                    jpegImage.Save(outputPath);
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
 * 1. When you need to embed a small preview image inside a JPEG file for faster loading in photo galleries.
 * 2. When you want to generate a red placeholder thumbnail for JPEGs that lack an existing thumbnail.
 * 3. When a digital asset management system requires a JFIF thumbnail to display image previews without decoding the full image.
 * 4. When you are creating JPEG files that must comply with legacy devices that read the JFIF thumbnail for quick preview.
 * 5. When you need to programmatically add or replace a JPEG's JFIF thumbnail in a batch processing pipeline using C#.
 */
