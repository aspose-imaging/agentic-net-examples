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

                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    Color[] frameBackgrounds = new Color[] { Color.Red, Color.Green, Color.Blue };

                    foreach (Color bgColor in frameBackgrounds)
                    {
                        using (RasterImage frame = (RasterImage)Image.Create(new BmpOptions(), width, height))
                        {
                            Graphics graphics = new Graphics(frame);
                            graphics.Clear(bgColor);
                            // Optionally draw the vector image onto the frame if needed:
                            // graphics.DrawImage(vectorImage, new Point(0, 0));
                            apngImage.AddFrame(frame);
                        }
                    }

                    apngImage.BackgroundColor = Color.White;
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