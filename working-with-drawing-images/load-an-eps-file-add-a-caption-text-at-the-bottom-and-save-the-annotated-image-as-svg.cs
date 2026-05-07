using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                int width = epsImage.Width;
                int height = epsImage.Height;

                var graphics = new SvgGraphics2D(width, height, 96);

                // Rasterize EPS to PNG in memory
                using (var ms = new MemoryStream())
                {
                    epsImage.Save(ms, new PngOptions());
                    ms.Position = 0;
                    using (var raster = (RasterImage)Image.Load(ms))
                    {
                        graphics.DrawImage(raster, new Point(0, 0));
                    }
                }

                // Add caption text at the bottom
                var font = new Font("Arial", 24, FontStyle.Regular);
                string caption = "Sample Caption";
                // Position near bottom-left corner
                graphics.DrawString(font, caption, new Point(10, height - 30), Color.Black);

                using (var svgImage = graphics.EndRecording())
                {
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}