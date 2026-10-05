// HOW-TO: Create 400x400 Yellow BMP Image from FileStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                BmpOptions options = new BmpOptions() { Source = new StreamSource(fs) };
                using (RasterImage canvas = (RasterImage)Image.Create(options, 400, 400))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.Yellow);
                    canvas.Save();
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
 * 1. When you need to generate a solid‑color BMP thumbnail on the fly for a reporting dashboard using Aspose.Imaging in C#.
 * 2. When an application must create a blank canvas of a specific size and fill it with a background color before drawing additional graphics.
 * 3. When you want to write a BMP file directly to a FileStream to avoid temporary files and control the output location programmatically.
 * 4. When a service produces colored placeholder images for missing assets and requires the image to be saved in BMP format for legacy compatibility.
 * 5. When you are automating batch creation of uniform‑size BMP images for testing image‑processing pipelines or performance benchmarks.
 */
