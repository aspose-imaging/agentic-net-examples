using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TIFF image
        using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
        {
            // Convert clipping path resources to a GraphicsPath
            var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter
                .ToGraphicsPath(tiff.ActiveFrame.PathResources.ToArray(), tiff.ActiveFrame.Size);

            // Create an SVG image with the same dimensions as the TIFF frame
            var svgOptions = new SvgOptions();
            using (Image svgImage = Image.Create(svgOptions, tiff.Width, tiff.Height))
            {
                // Draw the extracted path onto the SVG canvas
                Graphics graphics = new Graphics(svgImage);
                graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                // Save the SVG file
                svgImage.Save(outputPath, svgOptions);
            }
        }
    }
}