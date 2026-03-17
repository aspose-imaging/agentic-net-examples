using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class ExportTiffFrames
{
    static void Main()
    {
        // Path to the source multi‑page TIFF file
        string inputFilePath = @"C:\Images\multipage.tif";

        // Folder where extracted frames will be saved
        string outputFolder = @"C:\Images\Frames";

        // Desired output format for each frame (png, jpg, bmp, tiff)
        string outputFormat = "png";

        // Load the multi‑page TIFF using the provided load rule
        using (Image image = Image.Load(inputFilePath))
        {
            // Cast to TiffImage to access the Frames collection
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
                throw new InvalidOperationException("The loaded image is not a TIFF.");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Iterate through each frame in the TIFF
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                TiffFrame frame = tiffImage.Frames[i];

                // Create a temporary single‑frame image from the current TiffFrame
                using (TiffImage singleFrameImage = new TiffImage(frame))
                {
                    // Choose save options based on the desired output format
                    ImageOptionsBase saveOptions;
                    string outputFilePath;

                    switch (outputFormat.ToLower())
                    {
                        case "png":
                            saveOptions = new PngOptions();
                            outputFilePath = Path.Combine(outputFolder, $"frame_{i}.png");
                            break;
                        case "jpg":
                        case "jpeg":
                            saveOptions = new JpegOptions();
                            outputFilePath = Path.Combine(outputFolder, $"frame_{i}.jpg");
                            break;
                        case "bmp":
                            saveOptions = new BmpOptions();
                            outputFilePath = Path.Combine(outputFolder, $"frame_{i}.bmp");
                            break;
                        case "tif":
                        case "tiff":
                            saveOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                            outputFilePath = Path.Combine(outputFolder, $"frame_{i}.tif");
                            break;
                        default:
                            // Fallback to PNG if an unknown format is specified
                            saveOptions = new PngOptions();
                            outputFilePath = Path.Combine(outputFolder, $"frame_{i}.png");
                            break;
                    }

                    // Save the single frame using the provided save rule
                    singleFrameImage.Save(outputFilePath, saveOptions);
                }
            }
        }
    }
}