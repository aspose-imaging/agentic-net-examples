using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Load the TIFF image using Aspose.Imaging's Image.Load method
        using (var image = (TiffImage)Image.Load("Sample.tif"))
        {
            // Retrieve the clipping path resources from the active frame
            List<PathResource> clippingPaths = image.ActiveFrame.PathResources;

            // Iterate through each path and output its details
            foreach (var path in clippingPaths)
            {
                Console.WriteLine($"Path Name: {path.Name}");
                Console.WriteLine($"Block Id: {path.BlockId}");
                Console.WriteLine($"Number of Records: {path.Records?.Count ?? 0}");
                Console.WriteLine();
            }
        }
    }
}