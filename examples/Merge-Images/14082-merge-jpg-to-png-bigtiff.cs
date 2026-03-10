using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPG files to merge
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Output BigTIFF file
            string outputPath = "merged_output.tif";

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create source and BigTiff options
            Source source = new FileCreateSource(outputPath, false);
            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default) { Source = source };

            // Create BigTIFF canvas
            using (BigTiffImage canvas = (BigTiffImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Define destination rectangle on the canvas
                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        // Copy pixel data from source image to canvas
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image (no need to pass path again)
                canvas.Save();
            }
        }
    }
}