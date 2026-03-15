using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expected arguments: <DngPath> <OutputJpgPath> <JpgPath1> <JpgPath2> ...
        if (args.Length < 3)
        {
            throw new ArgumentException("Usage: <DngPath> <OutputJpgPath> <JpgPath1> [<JpgPath2> ...]");
        }

        string dngPath = args[0];
        string outputPath = args[1];
        string[] jpgPaths = new string[args.Length - 2];
        Array.Copy(args, 2, jpgPaths, 0, jpgPaths.Length);

        // Load DNG image to use its dimensions as part of the canvas size calculation
        using (DngImage dngImage = (DngImage)Image.Load(dngPath))
        {
            // Collect sizes of all images (DNG + JPGs)
            List<Size> sizeList = new List<Size>();
            sizeList.Add(dngImage.Size);

            foreach (string jpgPath in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                {
                    sizeList.Add(img.Size);
                }
            }

            // Calculate horizontal canvas size (sum widths, max height)
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizeList)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Prepare JPEG output options
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = fileSource,
                Quality = 90
            };

            // Create JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;

                // Draw each JPG onto the canvas horizontally
                foreach (string jpgPath in jpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound JPEG image
                canvas.Save();
            }
        }
    }
}