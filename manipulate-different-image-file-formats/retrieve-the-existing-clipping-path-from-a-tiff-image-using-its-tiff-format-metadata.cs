using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Load the TIFF image from file
        using (var image = (TiffImage)Image.Load("Sample.tif"))
        {
            // Access the clipping paths stored in the active frame's PathResources
            foreach (var path in image.ActiveFrame.PathResources)
            {
                // Display each clipping path's name
                Console.WriteLine($"Clipping Path: {path.Name}");
            }
        }
    }
}