// HOW-TO: Convert OTG to PNG with Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
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
 * 1. When a developer needs to display vector OTG graphics on a web page that only supports PNG images with alpha transparency.
 * 2. When an application must batch‑convert design assets from OTG to PNG while preserving the original transparent background for UI icons.
 * 3. When a reporting tool has to embed OTG diagrams into PDF or Word documents that require raster PNG files with no background color.
 * 4. When a mobile app imports OTG logos and needs to save them as PNGs so they render correctly over any background in the app.
 * 5. When a CI/CD pipeline uses Aspose.Imaging in C# to automate image conversion and must ensure that the resulting PNG retains transparency for downstream graphic workflows.
 */
