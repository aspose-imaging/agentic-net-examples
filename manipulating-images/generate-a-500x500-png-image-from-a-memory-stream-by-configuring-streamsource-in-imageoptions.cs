// HOW-TO: Create 500x500 White PNG Image With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions createOptions = new PngOptions() { Source = outSource };

            using (RasterImage canvas = (RasterImage)Image.Create(createOptions, 500, 500))
            {
                int[] whitePixels = Enumerable.Repeat(unchecked((int)0xFFFFFFFF), 500 * 500).ToArray();
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, 500, 500), whitePixels);
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
 * 1. When you need to programmatically generate a blank PNG canvas of a specific size for later drawing or watermarking in a C# application.
 * 2. When an automated report generator must create a placeholder image file without loading any external resources.
 * 3. When a web service has to produce a thumbnail‑size PNG on the fly and save it directly to disk using Aspose.Imaging.
 * 4. When a batch processing tool requires initializing a uniform white image before compositing other graphics layers.
 * 5. When a unit test needs a deterministic PNG file to verify image‑processing algorithms without relying on external files.
 */
