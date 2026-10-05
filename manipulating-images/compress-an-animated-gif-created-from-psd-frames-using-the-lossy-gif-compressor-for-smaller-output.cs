// HOW-TO: Compress Animated GIF Created From PSD Frames Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string psdPath1 = "frame1.psd";
            string psdPath2 = "frame2.psd";
            string psdPath3 = "frame3.psd";
            string outputPath = "output.gif";

            if (!File.Exists(psdPath1))
            {
                Console.Error.WriteLine($"File not found: {psdPath1}");
                return;
            }
            if (!File.Exists(psdPath2))
            {
                Console.Error.WriteLine($"File not found: {psdPath2}");
                return;
            }
            if (!File.Exists(psdPath3))
            {
                Console.Error.WriteLine($"File not found: {psdPath3}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage frame1 = (RasterImage)Image.Load(psdPath1))
            using (RasterImage frame2 = (RasterImage)Image.Load(psdPath2))
            using (RasterImage frame3 = (RasterImage)Image.Load(psdPath3))
            {
                RasterImage[] frames = new RasterImage[] { frame1, frame2, frame3 };
                using (Image gif = Image.Create(frames, true))
                {
                    GifOptions gifOptions = new GifOptions();
                    gif.Save(outputPath, gifOptions);
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
 * 1. When you need to generate a lightweight animated banner from multiple Photoshop (PSD) layers for a website.
 * 2. When you want to reduce the file size of an animated GIF created from PSD frames for faster email newsletter loading.
 * 3. When you have a series of PSD design iterations that must be combined into a single looping GIF for a mobile app.
 * 4. When you must programmatically assemble PSD files into an animated GIF on a server to automate a content pipeline.
 * 5. When you require a C# solution that loads PSD images, creates an animated GIF, and applies lossy compression for quicker page rendering.
 */
