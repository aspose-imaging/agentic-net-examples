using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            var resolutions = new (int width, int height)[]
            {
                (640, 480),
                (1280, 720),
                (1920, 1080)
            };

            foreach (var (width, height) in resolutions)
            {
                string outputPath = Path.Combine(outputDir, $"mask_{width}x{height}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Resize(width, height, ResizeType.NearestNeighbourResample);

                    var sw = System.Diagnostics.Stopwatch.StartNew();

                    MagicWandTool
                        .Select(image, new MagicWandSettings(width / 2, height / 2))
                        .Apply();

                    sw.Stop();

                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                    Console.WriteLine($"Resolution {width}x{height}: {sw.ElapsedMilliseconds} ms");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}