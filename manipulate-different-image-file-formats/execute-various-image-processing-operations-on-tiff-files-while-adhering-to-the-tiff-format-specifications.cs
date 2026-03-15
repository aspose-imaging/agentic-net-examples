using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class TiffProcessingDemo
{
    static void Main()
    {
        // Paths for input and output TIFF files
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output_processed.tif";

        // Load the existing TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TiffImage to access TIFF‑specific members
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
            {
                Console.WriteLine("The loaded file is not a TIFF image.");
                return;
            }

            // ----- Image processing on the active frame -----
            // Increase brightness by 30 (value range depends on image depth)
            tiffImage.ActiveFrame.AdjustBrightness(30);

            // Increase contrast by 0.2 (float, 0‑1 range)
            tiffImage.ActiveFrame.AdjustContrast(0.2f);

            // Rotate the image 90 degrees clockwise
            tiffImage.ActiveFrame.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Convert the active frame to grayscale
            tiffImage.ActiveFrame.Grayscale();

            // ----- Create a grayscale copy of the processed frame -----
            // Prepare options for the new grayscale frame
            TiffOptions grayFrameOptions = new TiffOptions(TiffExpectedFormat.Default);
            grayFrameOptions.Photometric = TiffPhotometrics.MinIsBlack; // Grayscale photometric
            grayFrameOptions.BitsPerSample = new ushort[] { 8 };       // 8‑bit grayscale

            // Create a new frame from the active frame using the grayscale options
            TiffFrame grayFrame = TiffFrame.CreateFrameFrom(tiffImage.ActiveFrame, grayFrameOptions);

            // Add the new grayscale frame to the TIFF image (now it has two frames)
            tiffImage.AddFrame(grayFrame);

            // ----- Save the modified TIFF image -----
            // Use default save options (preserve original compression, etc.)
            tiffImage.Save(outputPath);
        }

        Console.WriteLine("TIFF processing completed successfully.");
    }
}