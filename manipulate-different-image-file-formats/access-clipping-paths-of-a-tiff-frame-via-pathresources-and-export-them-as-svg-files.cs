// HOW-TO: Extract TIFF Frame Clipping Paths and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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
                int frameIndex = 0;
                foreach (var frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;
                    var pathResources = frame.PathResources;
                    int pathIndex = 0;
                    foreach (var pathResource in pathResources)
                    {
                        var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                            new[] { pathResource }, frame.Size);

                        string outputPath = $"output\\frame{frameIndex}_path{pathIndex}.svg";
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var svgOptions = new SvgOptions();
                        using (Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)Image.Create(svgOptions, frame.Width, frame.Height))
                        {
                            var graphics = new Graphics(svgImage);
                            graphics.DrawPath(new Pen(Color.Black), graphicsPath);
                            svgImage.Save(outputPath);
                        }

                        pathIndex++;
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

/*
 * Real-World Use Cases:
 * 1. When you need to convert the vector clipping paths embedded in a multi‑page TIFF into separate SVG files for web display or further editing.
 * 2. When a printing workflow requires extracting each page’s cutout shapes from a TIFF to generate scalable vector outlines for a pre‑press system.
 * 3. When you want to programmatically analyze or modify the vector masks of scanned documents by exporting them from TIFF to SVG using C#.
 * 4. When building a digital asset management tool that must index and render the vector paths of TIFF images as SVG thumbnails.
 * 5. When integrating Aspose.Imaging into a C# application to automate the extraction of TIFF path resources for use in GIS or CAD applications.
 */
