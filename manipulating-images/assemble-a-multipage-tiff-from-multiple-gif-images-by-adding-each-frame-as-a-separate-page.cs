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
        try
        {
            // Hardcoded input GIF paths
            string inputPath1 = @"c:\temp\gif1.gif";
            string inputPath2 = @"c:\temp\gif2.gif";
            string inputPath3 = @"c:\temp\gif3.gif";

            // Verify each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Hardcoded output TIFF path
            string outputPath = @"c:\temp\multipage.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load GIF images as RasterImage instances
            using (RasterImage gif1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage gif2 = (RasterImage)Image.Load(inputPath2))
            using (RasterImage gif3 = (RasterImage)Image.Load(inputPath3))
            {
                // Determine canvas size from the first image
                int width = gif1.Width;
                int height = gif1.Height;

                // Configure TIFF creation options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

                // Create a TIFF image with an initial blank frame
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Add each GIF as a separate TIFF frame
                    tiffImage.AddFrame(new TiffFrame(gif1));
                    tiffImage.AddFrame(new TiffFrame(gif2));
                    tiffImage.AddFrame(new TiffFrame(gif3));

                    // Remove the default initial frame created by Image.Create
                    TiffFrame initialFrame = tiffImage.ActiveFrame;
                    if (tiffImage.Frames.Length > 0)
                    {
                        tiffImage.ActiveFrame = tiffImage.Frames[0];
                        tiffImage.RemoveFrame(0);
                    }
                    initialFrame.Dispose();

                    // Save the multipage TIFF (output path already bound via FileCreateSource)
                    tiffImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}