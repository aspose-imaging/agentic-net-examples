// HOW-TO: Create BMP Image With Dark Gray Background And Yellow Diagonal Line In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 500;
            int height = 500;

            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.DarkGray);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Yellow, 5);
                graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width - 1, height - 1));

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
 * 1. When generating a simple placeholder graphic for a Windows desktop application, you can use this code to create a BMP with a dark gray canvas and a bright yellow diagonal line.
 * 2. When preparing test images for image‑processing algorithms that require a known pattern, the snippet quickly produces a BMP with a contrasting line for edge‑detection validation.
 * 3. When automating the creation of custom icons or badges for a reporting tool, you can programmatically draw a colored diagonal line on a BMP background using Aspose.Imaging.
 * 4. When building a batch process that adds a visual watermark to a series of BMP files, the example shows how to clear the image and draw a colored line as a simple watermark.
 * 5. When teaching beginners how to work with the Aspose.Imaging Graphics API in C#, this code demonstrates basic canvas initialization, background clearing, and line drawing on a BMP image.
 */
