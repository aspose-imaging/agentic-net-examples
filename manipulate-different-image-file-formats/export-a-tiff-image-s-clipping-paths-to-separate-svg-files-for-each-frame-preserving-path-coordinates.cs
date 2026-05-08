using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];

                    var svgGraphics = new SvgGraphics2D(frame.Width, frame.Height, 96);
                    using (SvgImage svgImage = svgGraphics.EndRecording())
                    {
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        svgImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}