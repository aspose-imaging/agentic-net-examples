using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath1 = @"C:\Images\input1.tif";
            string inputPath2 = @"C:\Images\input2.tif";
            string inputPath3 = @"C:\Images\input3.tif";
            string outputPath = @"C:\Images\output.tif";

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

            // Load the three source TIFF images
            using (TiffImage tiff1 = (TiffImage)Image.Load(inputPath1))
            using (TiffImage tiff2 = (TiffImage)Image.Load(inputPath2))
            using (TiffImage tiff3 = (TiffImage)Image.Load(inputPath3))
            {
                // Create a new multi‑frame TIFF using the first frame of the first image
                using (TiffImage result = new TiffImage(tiff1.Frames[0]))
                {
                    // Append remaining frames from the first image (if any)
                    for (int i = 1; i < tiff1.Frames.Length; i++)
                    {
                        result.AddFrame(tiff1.Frames[i]);
                    }

                    // Append all frames from the second and third images
                    result.Add(tiff2);
                    result.Add(tiff3);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the concatenated multi‑frame TIFF
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}