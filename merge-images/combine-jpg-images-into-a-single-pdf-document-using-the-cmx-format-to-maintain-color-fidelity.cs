using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG paths
        string[] jpgPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded CMX canvas path (used for size reference)
        string cmxPath = @"C:\Canvas\reference.cmx";

        // Hardcoded output PDF path
        string outputPdfPath = @"C:\Output\combined.pdf";

        // Validate input JPG files
        foreach (string path in jpgPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Validate CMX file
        if (!File.Exists(cmxPath))
        {
            Console.Error.WriteLine($"File not found: {cmxPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Temporary raster image path (intermediate JPEG before PDF conversion)
        string tempJpegPath = Path.Combine(Path.GetDirectoryName(outputPdfPath), "temp_canvas.jpg");
        Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));

        // Load CMX to obtain canvas dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Create a bound JPEG canvas with the same dimensions as the CMX canvas
            Source tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;

                // Merge each JPG onto the canvas vertically
                foreach (string jpgPath in jpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        // Define placement rectangle
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);

                        // Copy pixel data
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                        offsetY += img.Height;
                    }
                }

                // Save the bound JPEG canvas (writes to tempJpegPath)
                canvas.Save();
            }
        }

        // Convert the temporary JPEG canvas to a single-page PDF
        PdfOptions pdfOptions = new PdfOptions();
        using (Image tempImg = Image.Load(tempJpegPath))
        {
            tempImg.Save(outputPdfPath, pdfOptions);
        }

        // Optionally delete the temporary JPEG file
        try
        {
            File.Delete(tempJpegPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}