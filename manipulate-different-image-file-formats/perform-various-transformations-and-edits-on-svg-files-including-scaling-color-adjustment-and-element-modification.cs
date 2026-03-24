using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputScaledPath = @"C:\temp\output_scaled.svg";
        string outputModifiedPath = @"C:\temp\output_modified.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputScaledPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputModifiedPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            // ---------- Scaling ----------
            int newWidth = svgImage.Width * 2;
            int newHeight = svgImage.Height * 2;
            svgImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            svgImage.BackgroundColor = Color.LightGray; // Background color adjustment

            // Save the scaled SVG
            svgImage.Save(outputScaledPath);

            // ---------- Element Modification ----------
            // Create a graphics object based on the (now scaled) SVG image
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);
            graphics.DrawRectangle(new Pen(Color.Red, 5), 10, 10, newWidth - 20, newHeight - 20);

            // Finalize drawing and obtain the modified SVG image
            using (SvgImage modifiedImage = graphics.EndRecording())
            {
                // Save the modified SVG
                modifiedImage.Save(outputModifiedPath);
            }
        }
    }
}