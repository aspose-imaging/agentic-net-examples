using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Paths to the source and destination TIFF files
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output.tif";

        // Load the existing TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TiffImage to access TIFF‑specific functionality
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
                throw new InvalidOperationException("The loaded file is not a TIFF image.");

            // -----------------------------------------------------------------
            // Perform a series of image processing operations on the active frame
            // -----------------------------------------------------------------

            // Increase brightness by 20 units
            tiffImage.ActiveFrame.AdjustBrightness(20);

            // Increase contrast by a factor of 1.2
            tiffImage.ActiveFrame.AdjustContrast(1.2f);

            // Convert the active frame to grayscale
            tiffImage.ActiveFrame.Grayscale();

            // Resize the active frame to 800x600 pixels (default NearestNeighbourResample)
            tiffImage.ActiveFrame.Resize(800, 600);

            // -----------------------------------------------------------------
            // Create a new grayscale frame from the processed active frame
            // -----------------------------------------------------------------

            // Define options for the new frame – 8‑bit grayscale (MinIsBlack photometric)
            TiffOptions newFrameOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Photometric = TiffPhotometrics.MinIsBlack,
                BitsPerSample = new ushort[] { 8 }
            };

            // Create the new frame while preserving pixel data
            TiffFrame newFrame = TiffFrame.CreateFrameFrom(tiffImage.ActiveFrame, newFrameOptions);

            // Add the newly created frame to the multi‑page TIFF image
            tiffImage.AddFrame(newFrame);

            // -----------------------------------------------------------------
            // Adjust image resolution (e.g., set to 300 DPI for both axes)
            // -----------------------------------------------------------------
            tiffImage.SetResolution(300, 300);

            // -----------------------------------------------------------------
            // Save the modified TIFF image to the specified output path
            // -----------------------------------------------------------------
            tiffImage.Save(outputPath);
        }
    }
}