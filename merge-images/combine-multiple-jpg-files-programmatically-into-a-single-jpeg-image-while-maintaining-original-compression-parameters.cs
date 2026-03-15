using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output merged JPEG file path
        string outputPath = "merged.jpg";

        // Collect image sizes
        List<Size> sizes = new List<Size>();

        // Prepare JPEG options based on the first image to preserve its compression parameters
        JpegOptions jpegOptions;
        using (JpegImage firstImg = new JpegImage(inputPaths[0]))
        {
            sizes.Add(firstImg.Size);
            jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = firstImg.JpegOptions?.Quality ?? 90,
                CompressionType = firstImg.JpegOptions?.CompressionType ?? JpegCompressionMode.Baseline,
                ColorType = firstImg.JpegOptions?.ColorType ?? JpegCompressionColorMode.YCbCr,
                BitsPerChannel = firstImg.JpegOptions?.BitsPerChannel ?? 8
            };
        }

        // Collect sizes of the remaining images
        for (int i = 1; i < inputPaths.Length; i++)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create a JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (output file is already bound via FileCreateSource)
            canvas.Save();
        }
    }
}