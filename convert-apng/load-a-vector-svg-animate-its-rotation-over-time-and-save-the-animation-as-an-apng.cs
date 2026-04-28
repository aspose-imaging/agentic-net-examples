using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int animationDurationMs = 2000; // total animation duration
            const int frameDurationMs = 100;      // duration per frame
            int frameCount = animationDurationMs / frameDurationMs;
            float angleStep = 360f / frameCount;

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDurationMs,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    for (int i = 0; i < frameCount; i++)
                    {
                        float angle = i * angleStep;

                        // Load a fresh copy of the SVG for each frame
                        using (Image tempVector = Image.Load(inputPath))
                        {
                            tempVector.Rotate(angle);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Rasterize the rotated SVG to PNG in memory
                                tempVector.Save(ms, new PngOptions());
                                ms.Position = 0;

                                using (RasterImage frame = (RasterImage)Image.Load(ms))
                                {
                                    apngImage.AddFrame(frame);
                                }
                            }
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