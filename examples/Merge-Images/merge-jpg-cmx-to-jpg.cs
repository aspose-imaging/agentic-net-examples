using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Paths
        string cmxPath = "canvas.cmx";
        string[] jpgPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "merged_output.jpg";

        // Load CMX to obtain canvas dimensions
        int canvasWidth;
        int canvasHeight;
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            canvasWidth = cmx.Width;
            canvasHeight = cmx.Height;
        }

        // Prepare JPEG creation options bound to the output file
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 100
        };

        // Create JPEG canvas with the dimensions from the CMX file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;

            // Merge each JPEG image horizontally onto the canvas
            foreach (string jpgPath in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file already bound via source)
            canvas.Save();
        }
    }
}