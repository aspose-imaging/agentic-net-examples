using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class SvgFontEmbeddingExample
{
    static void Main()
    {
        // Output SVG file path
        string outputPath = "output.svg";

        // Define image dimensions and resolution
        int width = 400;
        int height = 200;
        int dpi = 96;

        // Create an SVG graphics surface
        SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

        // Draw a text string using a TrueType font (e.g., Arial)
        Font font = new Font("Arial", 48, FontStyle.Regular);
        graphics.DrawString(font, "Hello Aspose!", new Point(10, 80), Color.DarkBlue);

        // Finalize the recording and obtain the SvgImage object
        using (SvgImage svgImage = graphics.EndRecording())
        {
            // Configure SVG export options
            SvgOptions options = new SvgOptions
            {
                // Keep text as text (not converted to shapes) so that fonts can be embedded
                TextAsShapes = false,

                // Use the built‑in resource keeper callback to embed fonts as base64 streams
                Callback = new SvgResourceKeeperCallback()
            };

            // Save the SVG file with embedded font resources
            svgImage.Save(outputPath, options);
        }

        Console.WriteLine($"SVG file saved to: {outputPath}");
    }
}