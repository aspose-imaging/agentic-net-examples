// HOW-TO: Create Animated GIF From Multiple PNG Frames In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input frame paths
            string frame1 = "frame1.png";
            string frame2 = "frame2.png";
            string frame3 = "frame3.png";

            // Verify input files exist
            if (!File.Exists(frame1))
            {
                Console.Error.WriteLine($"File not found: {frame1}");
                return;
            }
            if (!File.Exists(frame2))
            {
                Console.Error.WriteLine($"File not found: {frame2}");
                return;
            }
            if (!File.Exists(frame3))
            {
                Console.Error.WriteLine($"File not found: {frame3}");
                return;
            }

            // Output path
            string outputPath = "output/animated.gif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load frames and create animated GIF
            using (RasterImage img1 = (RasterImage)Image.Load(frame1))
            {
                using (RasterImage img2 = (RasterImage)Image.Load(frame2))
                {
                    using (RasterImage img3 = (RasterImage)Image.Load(frame3))
                    {
                        RasterImage[] frames = new RasterImage[] { img1, img2, img3 };
                        using (Image result = Image.Create(frames, true))
                        {
                            GifOptions gifOptions = new GifOptions();
                            gifOptions.LoopsCount = 0; // infinite loop
                            result.Save(outputPath, gifOptions);
                        }
                    }
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
 * 1. When you need to combine several PNG images into a single looping animated GIF for a web banner using C# and Aspose.Imaging.
 * 2. When you want to programmatically generate an infinite‑loop GIF slideshow from product photos stored as PNG files in a .NET application.
 * 3. When you must automate the creation of an animated GIF from frame assets during a build process without manual image editors.
 * 4. When you are building a desktop tool that assembles user‑selected PNG screenshots into a GIF preview for UI testing.
 * 5. When you require server‑side code that reads PNG frames, assembles them into an animated GIF, and saves it to a specific output folder in an ASP.NET service.
 */
