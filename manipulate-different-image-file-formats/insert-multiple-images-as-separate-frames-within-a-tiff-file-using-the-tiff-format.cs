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
        // Output TIFF file path
        string outputPath = "output.tif";

        // Input image files to be added as frames (modify paths as needed)
        string[] inputPaths = new string[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        // Configure TIFF options for the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Determine canvas size based on the first existing image, or fallback to 100x100
        int canvasWidth = 100;
        int canvasHeight = 100;
        if (inputPaths.Length > 0 && File.Exists(inputPaths[0]))
        {
            using (Image firstImg = Image.Load(inputPaths[0]))
            {
                canvasWidth = firstImg.Width;
                canvasHeight = firstImg.Height;
            }
        }

        // Create the TIFF image canvas
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            // Add each input image as a separate frame
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                    continue; // Skip missing files

                using (Image img = Image.Load(path))
                {
                    // Ensure the loaded image is a raster image
                    RasterImage raster = img as RasterImage;
                    if (raster == null)
                        continue;

                    // Create a TIFF frame from the raster image
                    TiffFrame frame = new TiffFrame(raster);

                    // Append the frame to the TIFF image
                    tiffImage.AddFrame(frame);
                }
            }

            // Remove the initially created default frame if additional frames were added
            if (tiffImage.Frames.Length > 1)
            {
                TiffFrame defaultFrame = tiffImage.ActiveFrame;
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
                defaultFrame.Dispose();
            }

            // Save the multi-frame TIFF file
            tiffImage.Save();
        }
    }
}