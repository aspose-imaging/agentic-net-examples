using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputDir = "output_paths";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.FileFormats.Tiff.TiffImage tiff = (Aspose.Imaging.FileFormats.Tiff.TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    Aspose.Imaging.FileFormats.Tiff.TiffFrame frame = tiff.Frames[i];
                    var resources = frame.PathResources;
                    if (resources == null) continue;

                    for (int j = 0; j < resources.Count; j++)
                    {
                        var pathResource = resources[j];

                        var svgGraphics = new SvgGraphics2D(frame.Width, frame.Height, 96);
                        // No drawing performed; just create empty SVG for each path resource

                        using (var svgImage = svgGraphics.EndRecording())
                        {
                            string outputPath = Path.Combine(outputDir, $"frame_{i}_path_{j}.svg");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            svgImage.Save(outputPath);
                        }
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