using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Magic wand reference point and threshold
        int pointX = 120;
        int pointY = 100;
        int threshold = 150;

        // Fill color
        Color fillColor = Color.Red;

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select region based on color similarity and apply the mask
            MagicWandTool
                .Select(image, new MagicWandSettings(pointX, pointY) { Threshold = threshold })
                .Apply();

            // Fill the selected region with the specified color
            Graphics graphics = new Graphics(image);
            graphics.FillRectangle(new SolidBrush(fillColor), new Rectangle(0, 0, image.Width, image.Height));

            // Save the result with transparency support
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}