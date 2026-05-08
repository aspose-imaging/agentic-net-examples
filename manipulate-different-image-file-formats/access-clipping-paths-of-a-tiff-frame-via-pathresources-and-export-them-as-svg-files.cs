using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF path
            string inputPath = "input.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int frameCount = tiff.Frames.Count();
                for (int i = 0; i < frameCount; i++)
                {
                    // Activate current frame
                    tiff.ActiveFrame = tiff.Frames[i];

                    // Retrieve clipping paths
                    var pathResources = tiff.ActiveFrame.PathResources;
                    if (pathResources == null || pathResources.Count == 0)
                        continue; // No paths to export

                    // Convert PathResources to a GraphicsPath
                    var graphicsPath = PathResourceConverter.ToGraphicsPath(pathResources.ToArray(), tiff.ActiveFrame.Size);

                    // Prepare output SVG path
                    string outputDir = "output";
                    Directory.CreateDirectory(outputDir);
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create SVG image bound to the output file
                    var svgOptions = new SvgOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (Image svgImage = Image.Create(svgOptions, tiff.ActiveFrame.Width, tiff.ActiveFrame.Height))
                    {
                        // Draw the clipping path onto the SVG canvas
                        var graphics = new Graphics(svgImage);
                        graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                        // Save the bound SVG image
                        svgImage.Save();
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