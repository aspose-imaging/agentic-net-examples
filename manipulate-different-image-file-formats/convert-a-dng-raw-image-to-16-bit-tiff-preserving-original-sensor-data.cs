// HOW-TO: Convert DNG Raw Image to 16‑Bit TIFF Preserving Sensor Data in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.dng");
            string outputPath = Path.Combine("Output", "image.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 },
                    Photometric = TiffPhotometrics.Rgb
                })
                {
                    dng.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photo‑editing application must import camera raw files and save them as lossless 16‑bit TIFFs for further editing.
 * 2. When a scientific imaging pipeline needs to archive raw sensor data from DNG files in a widely supported TIFF format.
 * 3. When a printing workflow requires high‑dynamic‑range TIFF images to preserve color depth before color‑managed output.
 * 4. When a batch‑processing tool converts large collections of DNG files to TIFF for compatibility with legacy image analysis software.
 * 5. When a machine‑learning project extracts raw pixel values from DNG images and stores them as 16‑bit TIFFs for training models.
 */
