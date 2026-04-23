using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputTiffPath = "input.tif";
            string outputTiffPath = "output.tif";

            // Additional frame image paths
            string framePath1 = "frame1.jpg";
            string framePath2 = "frame2.png";

            // Verify input files exist
            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(framePath1))
            {
                Console.Error.WriteLine($"File not found: {framePath1}");
                return;
            }
            if (!File.Exists(framePath2))
            {
                Console.Error.WriteLine($"File not found: {framePath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Load the base TIFF image from a memory stream
            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (var tiffStream = new MemoryStream(tiffBytes))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
                {
                    // Load first additional frame and add to TIFF
                    using (RasterImage raster1 = (RasterImage)Image.Load(framePath1))
                    {
                        TiffFrame frame1 = new TiffFrame(raster1);
                        tiffImage.AddFrame(frame1);
                    }

                    // Load second additional frame and add to TIFF
                    using (RasterImage raster2 = (RasterImage)Image.Load(framePath2))
                    {
                        TiffFrame frame2 = new TiffFrame(raster2);
                        tiffImage.AddFrame(frame2);
                    }

                    // Save the updated multi-frame TIFF
                    tiffImage.Save(outputTiffPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}