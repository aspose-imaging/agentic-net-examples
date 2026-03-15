using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image files to be added as frames
        string[] inputPaths = new[]
        {
            "image1.jpg",
            "image2.png",
            "image3.tif"
        };

        // Output multi‑page TIFF file
        string outputPath = "output.tif";

        // Load the first image to obtain canvas size
        using (Image firstImg = Image.Load(inputPaths[0]))
        {
            // Configure TIFF creation options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create the TIFF image with the size of the first frame
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, firstImg.Width, firstImg.Height))
            {
                // Preserve the automatically created default frame for later removal
                TiffFrame defaultFrame = tiffImage.ActiveFrame;

                // Add the first image as a frame
                TiffFrame frame0 = new TiffFrame((RasterImage)firstImg);
                tiffImage.AddFrame(frame0);
                // Dispose the source image after frame creation
                firstImg.Dispose();

                // Process remaining images
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (Image img = Image.Load(inputPaths[i]))
                    {
                        TiffFrame frame = new TiffFrame((RasterImage)img);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Remove the initial empty frame
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
                defaultFrame.Dispose();

                // Save the multi‑page TIFF (source already bound)
                tiffImage.Save();
            }
        }
    }
}