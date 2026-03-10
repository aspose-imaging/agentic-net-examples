using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file (used as canvas reference)
        string cdrPath = @"C:\Images\canvas.cdr";

        // JPG images to merge
        string[] jpgPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Output merged JPG file
        string outputPath = @"C:\Images\merged_output.jpg";

        // Load CDR image to obtain canvas dimensions
        using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
        {
            int canvasWidth = cdrImage.Width;
            int canvasHeight = cdrImage.Height;

            // Prepare output source and JPEG options
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 100
            };

            // Create JPEG canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string jpgPath in jpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        // Define destination rectangle on the canvas
                        Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);

                        // Copy pixels from the source image to the canvas
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                        // Update horizontal offset for next image
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (no need to pass path again)
                canvas.Save();
            }
        }
    }
}