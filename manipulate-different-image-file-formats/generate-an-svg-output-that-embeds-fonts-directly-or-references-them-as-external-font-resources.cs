using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg; // For SvgResourceKeeperCallback
using Aspose.Imaging; // For Font, FontStyle, Color, Point

class Program
{
    static void Main()
    {
        // Output directory (ensure it exists)
        string outputDir = @"c:\temp\";

        // Define SVG canvas size and resolution
        int width = 400;
        int height = 200;
        int dpi = 96;

        // Create an SVG graphics context
        SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

        // Prepare a font (Arial, 48pt, regular)
        Font font = new Font("Arial", 48, FontStyle.Regular);

        // Draw a text string – this will be kept as a text element (not converted to shapes)
        graphics.DrawString(font, "Hello Aspose!", new Point(10, 100), Color.DarkBlue);

        // Finish recording and obtain the SvgImage object
        using (SvgImage svgImage = graphics.EndRecording())
        {
            // Configure SVG export options
            SvgOptions saveOptions = new SvgOptions
            {
                // Keep text as <text> elements so fonts can be embedded or referenced
                TextAsShapes = false,

                // Use the default resource keeper callback which embeds fonts as base64 by default
                Callback = new SvgResourceKeeperCallback(),

                // No compression – plain SVG file
                Compress = false
            };

            // Save the SVG file with embedded fonts
            string outputPath = System.IO.Path.Combine(outputDir, "output.svg");
            svgImage.Save(outputPath, saveOptions);
        }
    }
}