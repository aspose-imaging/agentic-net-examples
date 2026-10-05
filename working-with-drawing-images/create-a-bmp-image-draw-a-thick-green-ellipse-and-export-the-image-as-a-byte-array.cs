// HOW-TO: Create BMP with Green Ellipse and Save as File in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var createOptions = new BmpOptions();
            using (var image = Image.Create(createOptions, 200, 200) as RasterImage)
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 5);
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(20, 20, 160, 120);
                graphics.DrawEllipse(pen, rect);

                var saveOptions = new BmpOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a BMP thumbnail that highlights a region with a green outline for a reporting dashboard.
 * 2. When you want to programmatically create a simple graphic, such as a green ellipse, to embed in a Windows Forms application without using external image editors.
 * 3. When an automated service must produce a BMP file with a custom shape for printing labels or receipts.
 * 4. When you are building a test suite that requires a known BMP image containing a specific ellipse to validate image‑processing algorithms.
 * 5. When you need to create a BMP image on the fly and later convert it to a byte array for transmission over a network or storage in a database.
 */
