using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Temporary PSD file path
        string tempPsdPath = "merged.psd";

        // Final merged JPEG output path
        string outputJpgPath = "merged.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
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

        // Create PSD canvas bound to a file
        Source psdSource = new FileCreateSource(tempPsdPath, false);
        PsdOptions psdOptions = new PsdOptions { Source = psdSource };
        using (Image psdCanvas = Image.Create(psdOptions, newWidth, newHeight))
        {
            // Draw each JPEG onto the PSD canvas
            Graphics graphics = new Graphics(psdCanvas);
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    graphics.DrawImage(img, new Rectangle(offsetX, 0, img.Width, img.Height));
                    offsetX += img.Width;
                }
            }

            // Save the bound PSD file
            psdCanvas.Save();
        }

        // Load the created PSD and save it as JPEG
        using (Image psdImage = Image.Load(tempPsdPath))
        {
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputJpgPath, false),
                Quality = 90
            };
            psdImage.Save(outputJpgPath, jpegOptions);
        }
    }
}