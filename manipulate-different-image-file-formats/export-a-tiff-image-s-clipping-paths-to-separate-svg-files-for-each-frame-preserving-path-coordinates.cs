using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    string outputPath = Path.Combine(outputDir, $"frame{frameIndex}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var svgGraphics = new SvgGraphics2D(frame.Width, frame.Height, 96);
                    using (SvgImage svgImage = svgGraphics.EndRecording())
                    {
                        svgImage.Save(outputPath);
                    }

                    frameIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}