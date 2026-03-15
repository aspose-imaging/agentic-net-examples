using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] = CMX canvas path
        // args[1] = output PDF path
        // args[2...] = JPG image paths to merge
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <CMXPath> <OutputPdfPath> <JpgPath1> [JpgPath2] ...");
            return;
        }

        string cmxPath = args[0];
        string outputPdfPath = args[1];
        string[] jpgPaths = new string[args.Length - 2];
        Array.Copy(args, 2, jpgPaths, 0, jpgPaths.Length);

        // Load CMX to obtain canvas dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Create a temporary JPEG canvas bound to a file
            string tempJpegPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
            Source jpegSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = jpegSource,
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string jpgPath in jpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        // Ensure the image fits within the remaining canvas height
                        if (offsetY + img.Height > canvasHeight)
                            break;

                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound JPEG canvas
                canvas.Save();
            }

            // Load the temporary JPEG and save as PDF
            using (Image pdfSource = Image.Load(tempJpegPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfSource.Save(outputPdfPath, pdfOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempJpegPath))
                File.Delete(tempJpegPath);
        }
    }
}