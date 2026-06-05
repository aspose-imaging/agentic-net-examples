using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output.jp2";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Jpeg2000Options options = new Jpeg2000Options();
            options.BufferSizeHint = 64;
            options.Irreversible = true;
            options.Codec = Jpeg2000Codec.J2K;

            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                Graphics graphics = new Graphics(jpeg2000Image);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                }

                jpeg2000Image.Save(outputPath);
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
 * 1. When a developer needs to generate a JPEG2000 placeholder image with a solid background for a web application that requires lossless compression and custom buffer settings.
 * 2. When building a batch image conversion tool that creates JPEG2000 files from scratch with a specific color fill and optimized memory usage for large‑scale processing.
 * 3. When implementing a digital archiving system that stores scanned documents as JPEG2000 images and needs to initialize blank pages with a uniform color before adding content.
 * 4. When creating test assets for a medical imaging workflow that uses the J2K codec and requires a known background color to validate rendering pipelines.
 * 5. When developing a graphics library that programmatically produces solid‑color JPEG2000 tiles for map tiling services, controlling buffer size to improve performance.
 */