using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image file paths (replace with actual paths)
        List<string> jpegPaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg"
        };

        // Collect sizes of all JPEG images to determine ICO canvas size
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in jpegPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine maximum width and height among the images
        int maxWidth = 0;
        int maxHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizes)
        {
            if (sz.Width > maxWidth) maxWidth = sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create ICO options (default uses PNG frames with 32 bits per pixel)
        IcoOptions icoOptions = new IcoOptions();

        // Create an ICO image with the calculated canvas size
        using (Aspose.Imaging.FileFormats.Ico.IcoImage icoImage = new Aspose.Imaging.FileFormats.Ico.IcoImage(maxWidth, maxHeight, icoOptions))
        {
            // Add each JPEG as a page (frame) to the ICO image
            foreach (string path in jpegPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    icoImage.AddPage(img);
                }
            }

            // Save the resulting ICO file
            icoImage.Save("merged_output.ico");
        }
    }
}