// HOW-TO: Create 200x200 Red BMP Image and Save to File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Red);
                canvas.Save();
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
 * 1. When generating a solid‑color placeholder image for a UI mockup or testing layout rendering in a .NET application.
 * 2. When programmatically creating a red badge or icon of a fixed size to embed in reports or dashboards.
 * 3. When needing to produce a BMP file with a known background color for legacy hardware or embedded systems that only support BMP.
 * 4. When automating the creation of a red background texture for game assets or video‑processing pipelines using C#.
 * 5. When building a batch process that creates uniformly sized red images for printing proofs or color calibration.
 */
