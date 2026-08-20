// HOW-TO: Create BMP with Thick Black Border and Red Inner Rectangle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = @"c:\temp\bordered.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 400;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Thick outer border
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 10),
                    new Aspose.Imaging.Rectangle(0, 0, width, height));

                // Inner rectangle
                int inset = 30;
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 5),
                    new Aspose.Imaging.Rectangle(inset, inset, width - 2 * inset, height - 2 * inset));

                // Save the image (output already bound)
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
 * 1. When you need to generate a BMP placeholder image with a visible frame for UI mock‑ups.
 * 2. When you want to programmatically add a thick black border around a photo and highlight an inner area with a colored rectangle.
 * 3. When creating printable labels that require a bold outer edge and a contrasting inner box for barcode placement.
 * 4. When producing custom graphics for reports where a defined margin and highlighted content region are required.
 * 5. When automating the creation of game assets that need a solid background with a distinct border and inner panel for icons.
 */
