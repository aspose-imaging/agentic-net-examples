using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image file paths
        string[] imagePaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output merged JPEG file path
        string outputPath = "merged_output.jpg";

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create JPEG options with bound file source
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

        // Create JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            // Merge each image onto the canvas horizontally
            int offsetX = 0;
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound JPEG image (no need to pass path again)
            canvas.Save();
        }
    }
}