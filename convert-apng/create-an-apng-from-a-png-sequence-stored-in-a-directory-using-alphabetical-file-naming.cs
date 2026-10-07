// HOW-TO: Create Animated PNG From Sequential PNG Files In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "input";
            string outputPath = "output/output.apng";

            string[] inputFiles = new[]
            {
                Path.Combine(inputDir, "frame1.png"),
                Path.Combine(inputDir, "frame2.png"),
                Path.Combine(inputDir, "frame3.png")
            };

            foreach (var file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage first = (RasterImage)Image.Load(inputFiles[0]))
            {
                int width = first.Width;
                int height = first.Height;

                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                {
                    apng.AddFrame(first);

                    for (int i = 1; i < inputFiles.Length; i++)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(inputFiles[i]))
                        {
                            apng.AddFrame(frame);
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
 * 1. When you need to combine a series of PNG images into a single animated PNG for web or app animations.
 * 2. When you want to generate an APNG from frames stored in a folder with alphabetical naming for consistent playback order.
 * 3. When you need to programmatically create a lossless animated image with custom frame timing using Aspose.Imaging in a .NET application.
 * 4. When you are building a reporting tool that visualizes step‑by‑step screenshots as an animated PNG.
 * 5. When you have to automate the conversion of exported design assets (PNG sequence) into a single APNG for inclusion in documentation or UI components.
 */
