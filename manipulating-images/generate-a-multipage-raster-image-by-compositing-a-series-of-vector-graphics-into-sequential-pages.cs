using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input vector files and output TIFF path
        string[] vectorPaths = {
            @"C:\Images\vector1.svg",
            @"C:\Images\vector2.svg",
            @"C:\Images\vector3.svg"
        };
        string outputPath = @"C:\Images\MultipageOutput.tif";

        // Verify input files exist
        foreach (string path in vectorPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine canvas size from the first vector image
        int canvasWidth = 0;
        int canvasHeight = 0;
        using (Image firstVector = Image.Load(vectorPaths[0]))
        {
            canvasWidth = firstVector.Width;
            canvasHeight = firstVector.Height;
        }

        // Create TIFF options with bound file source
        Source tiffSource = new FileCreateSource(outputPath, false);
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Source = tiffSource,
            Photometric = TiffPhotometrics.Rgb,
            BitsPerSample = new ushort[] { 8, 8, 8 }
        };

        // Create the multipage TIFF canvas
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            foreach (string vectorPath in vectorPaths)
            {
                // Load vector image
                using (Image vectorImage = Image.Load(vectorPath))
                {
                    // Rasterize vector to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            Source = new StreamSource(ms)
                        };
                        vectorImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized PNG as RasterImage
                        using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                        {
                            // Create a TIFF frame from the raster image and add to TIFF
                            TiffFrame frame = new TiffFrame(rasterImage);
                            tiffImage.AddFrame(frame);
                        }
                    }
                }
            }

            // Remove the default initial frame created by Image.Create
            TiffFrame activeFrame = tiffImage.ActiveFrame;
            if (tiffImage.Frames.Length > 1)
            {
                tiffImage.ActiveFrame = tiffImage.Frames[1];
                tiffImage.RemoveFrame(0);
            }
            activeFrame.Dispose();

            // Save the multipage TIFF
            tiffImage.Save();
        }
    }
}