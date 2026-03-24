using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output JPG file
        string outputPath = @"C:\Images\output.jpg";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Create a list to hold TIFF frames
        List<TiffFrame> tiffFrames = new List<TiffFrame>();

        // Load each JPG and convert it to a TIFF frame
        foreach (string inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage (base for bitmap formats)
                RasterImage raster = img as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine($"Unable to process image: {inputPath}");
                    return;
                }

                // Create a TIFF frame from the raster image
                TiffFrame frame = new TiffFrame(raster);
                tiffFrames.Add(frame);
            }
        }

        // Create a multi‑frame TIFF image from the collected frames
        using (TiffImage tiffImage = new TiffImage(tiffFrames.ToArray()))
        {
            // Ensure the directory for the intermediate TIFF exists
            string tempTiffPath = @"C:\Images\temp_intermediate.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));

            // Save the multi‑page TIFF
            tiffImage.Save(tempTiffPath);
        }

        // Load the intermediate TIFF to combine its frames into a single JPEG
        using (Image tiffImg = Image.Load(@"C:\Images\temp_intermediate.tif"))
        {
            TiffImage multiPageTiff = tiffImg as TiffImage;
            if (multiPageTiff == null)
            {
                Console.Error.WriteLine("Failed to load intermediate TIFF as a multi‑page TIFF.");
                return;
            }

            // Determine combined image dimensions (horizontal concatenation)
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (TiffFrame frame in multiPageTiff.Frames)
            {
                totalWidth += frame.Width;
                if (frame.Height > maxHeight)
                    maxHeight = frame.Height;
            }

            // Prepare JPEG options with a file create source
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Source = new FileCreateSource(outputPath, false);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a blank JPEG image with the combined dimensions
            using (Image combinedImg = Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                Graphics graphics = new Graphics(combinedImg);
                int offsetX = 0;

                // Draw each TIFF frame onto the combined image
                foreach (TiffFrame frame in multiPageTiff.Frames)
                {
                    graphics.DrawImage(frame, offsetX, 0);
                    offsetX += frame.Width;
                }

                // Save the final combined JPEG
                combinedImg.Save();
            }
        }
    }
}