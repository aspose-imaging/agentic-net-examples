// HOW-TO: Create PSD File with Ellipse Shape Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);

            PsdOptions options = new PsdOptions();
            options.Source = source;
            options.Version = 5;

            int width = 300;
            int height = 200;

            using (var psd = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(psd);
                graphics.Clear(Aspose.Imaging.Color.White);
                Pen pen = new Pen(Aspose.Imaging.Color.Black);
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 200, 100));
                psd.Save();
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
 * 1. When you need to programmatically generate a Photoshop PSD file that contains a vector ellipse for use in design mockups.
 * 2. When you want to add a simple black ellipse to a blank PSD canvas as a placeholder for UI elements in automated testing.
 * 3. When creating batch scripts that produce indexed PSD files with basic shapes for printing templates.
 * 4. When integrating Aspose.Imaging into a C# application to draw geometric shapes on PSD layers before exporting to Photoshop.
 * 5. When building a server‑side service that generates PSD assets with custom ellipse graphics for marketing materials.
 */
