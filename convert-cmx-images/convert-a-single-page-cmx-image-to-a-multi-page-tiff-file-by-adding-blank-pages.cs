using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                // Rasterize CMX to a temporary PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        Source = new StreamSource(memoryStream)
                    };
                    cmx.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        // Create the first TIFF frame from the rasterized CMX
                        TiffFrame firstFrame = new TiffFrame(raster);

                        // Initialize TIFF options with a file create source
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            Source = new FileCreateSource(outputPath, false),
                            Photometric = TiffPhotometrics.Rgb,
                            BitsPerSample = new ushort[] { 8, 8, 8 }
                        };

                        // Create a TIFF image with the first frame
                        using (TiffImage tiffImage = new TiffImage(firstFrame))
                        {
                            // Add blank pages (frames) – here we add two blank pages as an example
                            for (int i = 0; i < 2; i++)
                            {
                                TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);
                                tiffImage.AddFrame(blankFrame);
                            }

                            // Save the multi‑page TIFF
                            tiffImage.Save();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}