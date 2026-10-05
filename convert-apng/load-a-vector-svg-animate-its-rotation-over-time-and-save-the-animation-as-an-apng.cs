// HOW-TO: Create Rotating SVG Animation and Export as APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100
                };

                using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(apngOptions, width, height))
                {
                    int frameCount = 36;
                    double angleStep = 360.0 / frameCount;

                    for (int i = 0; i < frameCount; i++)
                    {
                        double angle = i * angleStep;

                        BmpOptions bmpOptions = new BmpOptions();
                        using (Aspose.Imaging.Image frameCanvas = Aspose.Imaging.Image.Create(bmpOptions, width, height))
                        {
                            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(frameCanvas);
                            graphics.Clear(Aspose.Imaging.Color.Transparent);

                            graphics.TranslateTransform(width / 2, height / 2);
                            graphics.RotateTransform((float)angle);
                            graphics.TranslateTransform(-width / 2, -height / 2);

                            graphics.DrawImage(vectorImage, new Aspose.Imaging.Point(0, 0));

                            apngImage.AddFrame((Aspose.Imaging.RasterImage)frameCanvas);
                        }
                    }

                    apngImage.Save();
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
 * 1. When you need to generate a rotating logo for a website banner and deliver it as a lightweight animated PNG using C#.
 * 2. When you want to programmatically convert a vector icon into a frame‑by‑frame spin animation for mobile app splash screens.
 * 3. When an e‑learning platform requires a looping rotation of a diagram and you must produce the animation without rasterizing the SVG beforehand.
 * 4. When you are building a desktop tool that visualizes mechanical parts turning and need to save the result as an APNG for easy sharing.
 * 5. When you need to automate the creation of animated product previews from SVG assets for marketing emails using Aspose.Imaging for .NET.
 */
