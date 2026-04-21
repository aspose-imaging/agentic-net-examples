using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
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

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                var resources = tiff.ActiveFrame.PathResources;
                int index = 0;
                foreach (var res in resources)
                {
                    // Convert the clipping path to a GraphicsPath
                    Aspose.Imaging.GraphicsPath graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                        new[] { res }, tiff.ActiveFrame.Size);

                    // Create SVG graphics and draw the path
                    var svgGraphics = new SvgGraphics2D(tiff.ActiveFrame.Width, tiff.ActiveFrame.Height, 96);
                    svgGraphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                    // Finalize SVG image
                    using (var svgImage = svgGraphics.EndRecording())
                    {
                        string outputPath = Path.Combine("output", $"clipping_{index}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        svgImage.Save(outputPath);
                    }

                    index++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}