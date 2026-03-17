using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class ExportTiffFrames
{
    static void Main()
    {
        // Path to the source multi‑frame TIFF file
        string inputPath = @"C:\Temp\source_multiframe.tif";

        // Directory where individual frame files will be saved
        string outputDir = @"C:\Temp\Frames";
        Directory.CreateDirectory(outputDir);

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frames
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
                throw new InvalidOperationException("The loaded image is not a TIFF.");

            // Iterate through each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Create a copy of the current frame (clone via RasterImage constructor)
                TiffFrame copiedFrame = new TiffFrame((RasterImage)tiffImage.Frames[i]);

                // Wrap the copied frame into a new TiffImage instance
                using (TiffImage singleFrameImage = new TiffImage(copiedFrame))
                {
                    // Prepare save options that conform to TIFF specifications
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        // Preserve typical TIFF settings; adjust as needed
                        BitsPerSample = new ushort[] { 8, 8, 8 },
                        ByteOrder = TiffByteOrder.LittleEndian,
                        Compression = TiffCompressions.Lzw,
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Build output file name
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.tif");

                    // Save the single‑frame TIFF
                    singleFrameImage.Save(outputPath, saveOptions);
                }
            }
        }
    }
}