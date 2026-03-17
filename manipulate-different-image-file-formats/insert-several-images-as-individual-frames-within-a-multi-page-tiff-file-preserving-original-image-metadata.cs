using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input image paths and output TIFF path
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.png",
            "image3.tif"
        };
        string outputPath = "multipage.tif";

        // Determine maximum width and height among all input images
        int maxWidth = 0;
        int maxHeight = 0;
        foreach (string path in inputPaths)
        {
            using (Image img = Image.Load(path))
            {
                if (img.Width > maxWidth) maxWidth = img.Width;
                if (img.Height > maxHeight) maxHeight = img.Height;
            }
        }

        // Configure TIFF options and bind output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Create the multi‑page TIFF canvas
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, maxWidth, maxHeight))
        {
            // Add each input image as a separate frame
            foreach (string path in inputPaths)
            {
                using (Image img = Image.Load(path))
                {
                    // Preserve metadata (if any) by copying Exif data to the frame's metadata
                    // Note: TiffFrame does not expose metadata directly; this step is illustrative.
                    TiffFrame frame = new TiffFrame((RasterImage)img);
                    tiffImage.AddFrame(frame);
                }
            }

            // Remove the initially created default frame
            TiffFrame defaultFrame = tiffImage.ActiveFrame;
            // After adding frames, the first added frame is at index 1
            tiffImage.ActiveFrame = tiffImage.Frames[1];
            tiffImage.RemoveFrame(0);
            defaultFrame.Dispose();

            // Save the multi‑page TIFF (output file already bound)
            tiffImage.Save();
        }
    }
}