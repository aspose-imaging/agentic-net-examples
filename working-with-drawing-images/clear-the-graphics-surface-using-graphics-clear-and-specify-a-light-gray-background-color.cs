// HOW-TO: Create 500x500 PNG With Light Gray Background In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);
                image.Save(outputPath, pngOptions);
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
 * 1. When you need a blank 500 × 500 PNG placeholder with a light gray canvas for UI mock‑ups.
 * 2. When generating a solid‑color background image to serve as a base for further drawing operations in a C# graphics routine.
 * 3. When creating a template thumbnail that will later have text or icons overlaid in an automated report.
 * 4. When preparing a uniform light‑gray background for batch processing of images that must share the same dimensions and format.
 * 5. When automating the production of email‑newsletter or marketing assets that start with a light gray PNG background.
 */
