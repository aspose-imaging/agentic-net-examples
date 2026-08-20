// HOW-TO: Create BMP Image With Scaled Line Drawing In C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\Temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                int width = 200;
                int height = 100;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    graphics.ScaleTransform(2f, 2f);
                    graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(90, 10));
                    image.Save();
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
 * 1. When you need to generate a BMP file with a line that is automatically doubled in size for printing or UI overlays.
 * 2. When you want to create a simple diagram programmatically in C# and apply a scaling transformation to enlarge the graphics without manually recalculating coordinates.
 * 3. When building a batch process that produces thumbnail‑style line art in BMP format and requires consistent scaling across different image dimensions.
 * 4. When developing a testing tool that validates Aspose.Imaging’s ScaleTransform function by drawing a known line and checking its doubled length.
 * 5. When creating custom graphics for embedded devices that only support BMP and need scaled line elements to fit larger display areas.
 */
