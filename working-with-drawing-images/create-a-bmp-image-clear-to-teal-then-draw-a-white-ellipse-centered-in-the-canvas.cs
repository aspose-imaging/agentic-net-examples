// HOW-TO: Create A Teal BMP With White Ellipse Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string outputPath = @"c:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            var source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            int width = 500;
            int height = 500;
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Teal);
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.White, 2);
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(100, 100, 300, 300));
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
 * 1. When you need to generate a BMP file as a background for a game UI and highlight a region with a white ellipse.
 * 2. When creating placeholder images for testing image processing pipelines that require a solid teal canvas with a centered ellipse.
 * 3. When automating the production of simple icons or badges in BMP format where a teal background and white circular outline are required.
 * 4. When preparing custom map markers that consist of a teal square and a white elliptical border for GIS applications.
 * 5. When building a reporting tool that adds a highlighted elliptical overlay to teal‑colored BMP charts before saving them.
 */
