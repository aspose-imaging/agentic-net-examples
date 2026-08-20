// HOW-TO: Apply Alpha Blend with Zero Opacity to Preserve Background Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                background.Blend(new Point(0, 0), overlay, 0);
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, options);
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
 * 1. When you need to test that applying an overlay with 0% opacity does not alter the original PNG background during automated image processing.
 * 2. When verifying that a custom watermark routine respects transparency settings by blending an overlay at zero opacity and confirming the base image stays unchanged.
 * 3. When building a CI pipeline that checks image compositing logic, using Aspose.Imaging to blend a transparent layer and ensure the output matches the source background.
 * 4. When creating a preview tool that shows the effect of different opacity levels, you first blend with opacity 0 to capture the untouched background as a reference.
 * 5. When troubleshooting unexpected changes in layered graphics, you can isolate the issue by blending an overlay with zero opacity and confirming the background image remains identical.
 */
