using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Keep only the first clipping path if any
            var existingPaths = image.ActiveFrame.PathResources;
            if (existingPaths != null && existingPaths.Count > 0)
            {
                image.ActiveFrame.PathResources = existingPaths.Take(1).ToList();
            }

            // Create a new rectangular clipping path
            var figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

            var graphicsPath = new GraphicsPath();
            graphicsPath.AddFigure(figure);

            // Convert the GraphicsPath to PathResources and add to the image
            var newResources = PathResourceConverter.FromGraphicsPath(graphicsPath, image.Size);
            var updatedResources = image.ActiveFrame.PathResources.ToList();
            updatedResources.AddRange(newResources);
            image.ActiveFrame.PathResources = updatedResources;

            // Draw the new path on the image for visual verification
            var graphics = new Graphics(image);
            graphics.DrawPath(new Pen(Color.Red, 2), graphicsPath);

            // Save the modified TIFF
            image.Save(outputPath);
        }
    }
}