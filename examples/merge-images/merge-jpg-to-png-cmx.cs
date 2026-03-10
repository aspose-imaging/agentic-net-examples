using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input CMX file (used as canvas size reference)
            string cmxPath = "input.cmx";

            // JPG images to merge
            string[] jpgPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Output PNG file
            string outputPath = "merged_output.png";

            // Load CMX to obtain canvas dimensions
            using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
            {
                int canvasWidth = cmx.Width;
                int canvasHeight = cmx.Height;

                // Prepare PNG options with bound file source
                Source source = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = source };

                // Create PNG canvas with the dimensions from CMX
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    int offsetX = 0;

                    // Merge each JPG horizontally onto the canvas
                    foreach (string jpgPath in jpgPaths)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                        {
                            // Define placement rectangle on the canvas
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);

                            // Copy pixel data from JPG to canvas
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                            // Update horizontal offset for next image
                            offsetX += img.Width;
                        }
                    }

                    // Save the bound PNG image
                    canvas.Save();
                }
            }
        }
    }
}