// HOW-TO: Create BMP with Ellipse and Reset Graphics Transform in C# (Aspose.Imaging for .NET)
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
        string outputPath = "ellipse.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                Rectangle rect = new Rectangle(20, 20, 160, 120);
                graphics.DrawEllipse(pen, rect);

                graphics.ResetTransform();

                image.Save();
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
 * 1. When you need to generate a BMP thumbnail that contains a centered ellipse for a reporting dashboard.
 * 2. When you want to programmatically draw vector shapes on a bitmap and ensure subsequent drawing operations start from the default coordinate system.
 * 3. When you are building a C# utility that creates simple diagram elements, such as ellipses, and must save them as BMP files for legacy applications.
 * 4. When you require a reproducible way to clear transformations after drawing so that later graphics calls are not affected by previous scaling or rotation.
 * 5. When you are automating the creation of test images for image‑processing algorithms that expect a BMP image with a known geometric primitive.
 */
