// HOW-TO: How To Save GIF With Custom Color Depth And Dithering In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of an animated GIF while preserving visual quality by adjusting its color depth and dithering in a C# application.
 * 2. When you are building a web service that converts uploaded GIFs to a standardized palette for consistent display across browsers using Aspose.Imaging.
 * 3. When you want to re‑encode existing GIF animations with a specific dithering algorithm to meet branding color guidelines in a .NET backend.
 * 4. When you have to preprocess GIF assets for a mobile app, ensuring they use a limited number of colors to improve loading speed on low‑end devices.
 * 5. When you are automating batch processing of GIF files to enforce a uniform color depth before publishing them to a digital asset management system.
 */
