using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output WMZ file
        string outputPath = "merged.wmz";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create a blank JPEG canvas (unbound)
        JpegOptions jpegOptions = new JpegOptions();
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Draw each JPEG onto the canvas
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Prepare WMZ (compressed WMF) options
            WmfOptions wmfOptions = new WmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = new Size(newWidth, newHeight)
                }
            };

            // Save the merged image as WMZ
            canvas.Save(outputPath, wmfOptions);
        }
    }
}