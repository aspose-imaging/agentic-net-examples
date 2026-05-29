using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

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

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                const int totalFrames = 10;
                const int frameDurationMs = 100;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDurationMs,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    apng.RemoveAllFrames();

                    for (int i = 0; i < totalFrames; i++)
                    {
                        // Create a temporary raster canvas
                        string tempFile = Path.GetTempFileName();
                        PngOptions pngOpts = new PngOptions
                        {
                            Source = new FileCreateSource(tempFile, false)
                        };

                        using (RasterImage canvas = (RasterImage)Image.Create(pngOpts, width, height))
                        {
                            // Fill background with a color that changes each frame to simulate gradient animation
                            byte r = (byte)(i * 25);
                            byte g = (byte)(255 - i * 25);
                            byte b = (byte)(i * 15);
                            Color frameColor = Color.FromArgb(255, r, g, b);
                            SolidBrush brush = new SolidBrush(frameColor);

                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.Transparent);
                            graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));

                            // Draw the SVG onto the canvas
                            graphics.DrawImage(vectorImage, new Point(0, 0));

                            // Add the raster frame to the APNG
                            apng.AddFrame(canvas);
                        }

                        // Delete temporary file
                        try { File.Delete(Path.GetTempFileName()); } catch { }
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