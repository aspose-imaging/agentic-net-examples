using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class TiffFrameExporter
{
    static void Main()
    {
        // Path to the source multi‑frame TIFF file
        string inputTiffPath = @"C:\Images\source.tif";

        // Directory where extracted frames will be saved
        string outputDirectory = @"C:\Images\Frames";

        // Desired output image format (e.g., "png", "jpg", "bmp")
        string outputFormat = "png";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the TIFF image using Aspose.Imaging lifecycle (load)
        using (Image image = Image.Load(inputTiffPath))
        {
            // Cast to TiffImage to access the Frames collection
            TiffImage tiffImage = (TiffImage)image;

            // Iterate through each frame in the TIFF
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Retrieve the current frame
                TiffFrame frame = tiffImage.Frames[i];

                // Wrap the frame into a temporary TiffImage instance (required for Save)
                using (TiffImage frameImage = new TiffImage(frame))
                {
                    // Build the output file name (e.g., frame_0.png)
                    string outputFilePath = Path.Combine(outputDirectory, $"frame_{i}.{outputFormat}");

                    // Choose appropriate save options based on the requested format
                    if (outputFormat.Equals("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var pngOptions = new PngOptions();
                        frameImage.Save(outputFilePath, pngOptions);
                    }
                    else if (outputFormat.Equals("jpg", StringComparison.OrdinalIgnoreCase) ||
                             outputFormat.Equals("jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        var jpegOptions = new JpegOptions();
                        frameImage.Save(outputFilePath, jpegOptions);
                    }
                    else if (outputFormat.Equals("bmp", StringComparison.OrdinalIgnoreCase))
                    {
                        var bmpOptions = new BmpOptions();
                        frameImage.Save(outputFilePath, bmpOptions);
                    }
                    else
                    {
                        // Fallback: save using the default options (same format as source)
                        frameImage.Save(outputFilePath);
                    }
                }
            }
        }
    }
}