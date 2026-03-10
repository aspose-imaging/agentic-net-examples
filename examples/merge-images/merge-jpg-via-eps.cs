using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string epsPath = "background.eps";
        string jpgPath2 = "image2.jpg";
        string outputPath = "merged.jpg";

        // Temporary JPEG created from EPS
        string tempJpegPath = "temp_from_eps.jpg";

        // Convert EPS to JPEG (temporary)
        using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
        {
            Source epsSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions epsJpegOptions = new JpegOptions() { Source = epsSource, Quality = 100 };
            epsImage.Save(tempJpegPath, epsJpegOptions);
        }

        // List of JPEG images to merge (including the temporary one)
        string[] jpegPaths = new string[] { tempJpegPath, jpgPath2 };

        // Collect sizes of all JPEG images
        List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
        foreach (string path in jpegPaths)
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

        // Create JPEG canvas bound to output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions canvasOptions = new JpegOptions() { Source = outputSource, Quality = 100 };
        using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, newWidth, newHeight))
        {
            // Merge images horizontally
            int offsetX = 0;
            foreach (string path in jpegPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas
            canvas.Save();
        }

        // Cleanup temporary file
        if (System.IO.File.Exists(tempJpegPath))
        {
            System.IO.File.Delete(tempJpegPath);
        }
    }
}