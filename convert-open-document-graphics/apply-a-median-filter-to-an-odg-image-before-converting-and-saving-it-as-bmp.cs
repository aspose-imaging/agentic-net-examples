// HOW-TO: Convert ODG to BMP via PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.bmp");
            string tempPngPath = Path.Combine("Output", "temp.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                var bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to display an OpenDocument Graphics (ODG) illustration in a Windows application that only supports BMP images, you can convert the ODG to BMP using Aspose.Imaging in C#.
 * 2. When a legacy reporting system requires bitmap files but your source assets are stored as ODG, this code lets you batch‑convert them programmatically.
 * 3. When you must embed ODG diagrams into a PDF generator that only accepts BMP streams, you can first rasterize the ODG to PNG and then save it as BMP with Aspose.Imaging.
 * 4. When automating a migration from an OpenDocument‑based design workflow to a bitmap‑based asset pipeline, this snippet provides a simple C# solution to transform each ODG file to BMP.
 * 5. When a third‑party API expects BMP input but your graphics are created in LibreOffice Draw (ODG), you can use this code to convert the files on the fly without manual export.
 */
