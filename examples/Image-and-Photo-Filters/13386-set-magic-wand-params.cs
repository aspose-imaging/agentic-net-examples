using System;
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

        // Magic Wand parameters
        int referenceX = 120;
        int referenceY = 100;
        int tolerance = 150; // Threshold (tolerance)

        // Fill and border colors
        Aspose.Imaging.Color fillColor = Aspose.Imaging.Color.Red;
        Aspose.Imaging.Color borderColor = Aspose.Imaging.Color.Blue;

        // Load the image as a raster image
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a mask using Magic Wand with specified tolerance
            ImageMask mask = MagicWandTool.Select(image, new MagicWandSettings(referenceX, referenceY) { Threshold = tolerance });

            // Fill the selected area with the fill color
            using (Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image))
            {
                graphics.FillRectangle(new SolidBrush(fillColor), mask.Bounds);
                graphics.DrawRectangle(new Aspose.Imaging.Pen(borderColor, 1), mask.Bounds);
            }

            // Save the resulting image with alpha channel support
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}