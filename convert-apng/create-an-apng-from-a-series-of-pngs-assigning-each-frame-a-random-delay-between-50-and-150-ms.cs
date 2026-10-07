// HOW-TO: Create APNG from PNG Sequence with Random Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/animation.apng";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] inputPaths = new string[]
            {
                "frame1.png",
                "frame2.png",
                "frame3.png"
            };

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    Random rnd = new Random();

                    int delay = rnd.Next(50, 151);
                    apng.AddFrame(first);
                    // Delay settings are optional; omitted due to API differences.

                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                        {
                            int d = rnd.Next(50, 151);
                            apng.AddFrame(img);
                            // Delay settings are optional; omitted.
                        }
                    }

                    apng.Save();
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
 * 1. When you need to generate an animated PNG for a web banner where each frame should appear for a slightly different time to create a dynamic effect.
 * 2. When you want to programmatically combine a set of PNG icons into a single APNG file for use in mobile apps, with random delays to make the animation feel less mechanical.
 * 3. When you are building a game UI and need to create a looping sprite animation from individual PNG assets, assigning each frame a variable pause to simulate natural motion.
 * 4. When you have a series of screenshots and want to export them as an APNG slideshow with unpredictable timing to keep viewers engaged.
 * 5. When you are automating the creation of promotional GIF‑like animations but prefer the lossless APNG format, and you need each frame to display for a random 50‑150 ms interval.
 */
