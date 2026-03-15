using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Load the TIFF image using Aspose.Imaging (lifecycle rule)
        using (var image = (TiffImage)Image.Load("input.tif"))
        {
            // Retrieve clipping paths (PathResources) from the active frame
            List<PathResource> clippingPaths = image.ActiveFrame.PathResources;

            // Display the name of each clipping path
            foreach (var path in clippingPaths)
            {
                Console.WriteLine($"Clipping Path: {path.Name}");
            }

            // Optional: keep only the first clipping path and discard the rest
            if (clippingPaths.Count > 0)
            {
                image.ActiveFrame.PathResources = new List<PathResource> { clippingPaths[0] };
                // Save the modified image (save rule)
                image.Save("output.tif");
            }
        }
    }
}