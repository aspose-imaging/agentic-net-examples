using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source TIFF file
        string inputPath = "Sample.tif";

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve clipping paths (PathResources) from the active frame
            List<Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource> clippingPaths = image.ActiveFrame.PathResources;

            // Display the names of the clipping paths
            foreach (var path in clippingPaths)
            {
                Console.WriteLine($"Clipping Path Name: {path.Name}");
            }

            // Convert the clipping paths to a GraphicsPath for vector‑based editing
            Aspose.Imaging.GraphicsPath graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter
                .ToGraphicsPath(image.ActiveFrame.PathResources.ToArray(), image.ActiveFrame.Size);

            // Example: draw the clipping path outline on the image (optional)
            Graphics graphics = new Graphics(image);
            Pen pen = new Pen(Color.Red, 2);
            graphics.DrawPath(pen, graphicsPath);

            // Save the modified image (overwrites the original file)
            image.Save();
        }
    }
}