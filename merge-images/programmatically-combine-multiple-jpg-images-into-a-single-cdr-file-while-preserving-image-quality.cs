using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] = path to reference CDR canvas
        // args[1..args.Length-2] = paths to input JPG images
        // args[args.Length-1] = output JPEG file path
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <program> <canvas.cdr> <input1.jpg> [<input2.jpg> ...] <output.jpg>");
            return;
        }

        string cdrPath = args[0];
        string outputPath = args[args.Length - 1];

        // Load CDR canvas to obtain target dimensions
        int canvasWidth;
        int canvasHeight;
        using (CdrImage cdrCanvas = (CdrImage)Image.Load(cdrPath))
        {
            canvasWidth = cdrCanvas.Width;
            canvasHeight = cdrCanvas.Height;
        }

        // Prepare source for the output JPEG image
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = outputSource,
            Quality = 100
        };

        // Create JPEG canvas with dimensions matching the CDR reference
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            // Merge each input JPG horizontally onto the canvas
            for (int i = 1; i < args.Length - 1; i++)
            {
                string imgPath = args[i];
                using (RasterImage img = (RasterImage)Image.Load(imgPath))
                {
                    // Ensure the image fits within the remaining canvas width
                    int drawWidth = Math.Min(img.Width, canvasWidth - offsetX);
                    int drawHeight = Math.Min(img.Height, canvasHeight);

                    Rectangle bounds = new Rectangle(offsetX, 0, drawWidth, drawHeight);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(new Rectangle(0, 0, drawWidth, drawHeight)));
                    offsetX += drawWidth;
                    if (offsetX >= canvasWidth)
                        break; // No more space on the canvas
                }
            }

            // Save the bound image (outputPath is already bound via FileCreateSource)
            canvas.Save();
        }
    }
}