using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Path to the folder containing the source DNG image
        string dir = @"c:\temp\";

        // Load the DNG image using the standard Image.Load method
        using (Image image = Image.Load(dir + "input.dng"))
        {
            // Cast the generic Image to a DngImage to access DNG‑specific functionality
            DngImage dngImage = (DngImage)image;

            // Apply an edge detection filter to the whole image.
            // The Filter method takes a rectangle (the area to process) and a filter options object.
            dngImage.Filter(dngImage.Bounds, new EdgeDetectionFilterOptions());

            // Save the processed image. Here we choose PNG as the output format,
            // but any supported format can be used by providing the appropriate options.
            dngImage.Save(dir + "output.png", new PngOptions());
        }
    }
}