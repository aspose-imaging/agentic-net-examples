// HOW-TO: Create 250x250 BMP With Bezier Curve And Save To MemoryStream In C# (Aspose.Imaging for .NET)
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
            using (MemoryStream ms = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(ms);
                using (Image image = Image.Create(bmpOptions, 250, 250))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                    Point p0 = new Point(20, 200);
                    Point p1 = new Point(70, 20);
                    Point p2 = new Point(180, 20);
                    Point p3 = new Point(230, 200);
                    graphics.DrawBezier(pen, p0, p1, p2, p3);
                    image.Save();
                    Console.WriteLine($"BMP size in bytes: {ms.Length}");
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
 * 1. When you need to generate a bitmap thumbnail that contains a custom Bezier‑shaped logo entirely in memory for a web API response.
 * 2. When you want to programmatically create a 250 × 250 BMP background and draw a smooth curve for a diagram or UI element without writing intermediate files to disk.
 * 3. When you are building a reporting tool that embeds vector‑style curves into BMP images and streams them directly to a client application.
 * 4. When you need to test image‑processing pipelines by producing a known BMP image with a specific Bezier pattern for automated validation.
 * 5. When you are converting drawing commands into a BMP stream for use in email attachments or database storage where only a byte array is required.
 */
