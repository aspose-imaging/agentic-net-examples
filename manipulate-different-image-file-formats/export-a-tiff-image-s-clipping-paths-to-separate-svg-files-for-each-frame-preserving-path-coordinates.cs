using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        string inputPath = "input.tif";
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        using (var tiffImage = (TiffImage)Image.Load(inputPath))
        {
            int frameCount = tiffImage.Frames.Length;
            for (int i = 0; i < frameCount; i++)
            {
                var frame = tiffImage.Frames[i];
                tiffImage.ActiveFrame = frame;
                var pathResources = frame.PathResources;
                if (pathResources == null || pathResources.Count == 0)
                    continue;

                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    pathResources.ToArray(),
                    frame.Size);

                int width = frame.Width;
                int height = frame.Height;
                var svgGraphics = new SvgGraphics2D(width, height, 96);
                var graphics = new Graphics(svgGraphics);
                graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                using (var svgImage = svgGraphics.EndRecording())
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    svgImage.Save(outputPath);
                }
            }
        }
    }
}