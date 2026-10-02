// HOW-TO: Create a Yellow BMP Image of Specific Size in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            int width = 200;
            int height = 200;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Yellow);
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
 * 1. When you need to generate a solid‑color BMP placeholder image of a custom width and height for a reporting or UI mockup.
 * 2. When an automated process must create a bitmap file on the fly to serve as a background for dynamically rendered charts.
 * 3. When a server‑side application has to produce a simple colored image for email attachments without using external image editors.
 * 4. When you want to programmatically create a thumbnail canvas in BMP format before drawing additional graphics or text.
 * 5. When testing image‑processing pipelines that require a known‑size, single‑color bitmap as input data.
 */
