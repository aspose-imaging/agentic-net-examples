using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class InsertMultipleFramesIntoTiff
{
    static void Main()
    {
        // Directory where source images are located and where the resulting TIFF will be saved
        string sourceDir = @"C:\Images\";
        string outputPath = @"C:\Images\combined.tif";

        // List of source image file names to be added as separate frames
        string[] sourceFiles = new string[]
        {
            "image1.jpg",
            "image2.png",
            "image3.bmp"
        };

        // Collection to hold the created TiffFrame objects
        List<TiffFrame> tiffFrames = new List<TiffFrame>();

        // Create a TiffOptions instance that will be used for each frame
        TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
        frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        frameOptions.ByteOrder = TiffByteOrder.LittleEndian;
        frameOptions.Compression = TiffCompressions.Lzw;
        frameOptions.Photometric = TiffPhotometrics.Rgb;
        frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

        // Load each source image, convert it to a TiffFrame, and add to the collection
        foreach (string fileName in sourceFiles)
        {
            string fullPath = System.IO.Path.Combine(sourceDir, fileName);

            // Load the raster image (any supported format)
            using (RasterImage raster = (RasterImage)Image.Load(fullPath))
            {
                // Create a TiffFrame from the raster image using the predefined options
                TiffFrame frame = new TiffFrame(raster, frameOptions);
                tiffFrames.Add(frame);
            }
        }

        // Initialize a TiffImage with the array of frames
        using (TiffImage tiffImage = new TiffImage(tiffFrames.ToArray()))
        {
            // Save the multi‑frame TIFF to the specified path
            tiffImage.Save(outputPath);
        }
    }
}