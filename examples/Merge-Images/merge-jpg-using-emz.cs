using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create an unbound JPEG canvas
        JpegOptions createOptions = new JpegOptions();
        using (JpegImage canvas = (JpegImage)Image.Create(createOptions, newWidth, newHeight))
        {
            // Merge images side by side
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Prepare EMF (EMZ) save options with compression
            EmfOptions emfOptions = new EmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = canvas.Size
                }
            };

            // Save the merged image as EMZ (compressed EMF)
            string outputPath = "merged_output.emz";
            canvas.Save(outputPath, emfOptions);
        }
    }
}