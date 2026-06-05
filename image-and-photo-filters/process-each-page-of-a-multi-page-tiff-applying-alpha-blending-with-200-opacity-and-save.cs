using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Process each frame (page) individually
                foreach (TiffFrame frame in tiffImage.Frames)
                {
                    // Load all pixels of the current frame
                    Aspose.Imaging.Color[] pixels = tiffImage.LoadPixels(frame.Bounds);

                    // Apply alpha blending with opacity = 200 (out of 255)
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        Aspose.Imaging.Color c = pixels[i];
                        // Preserve RGB, set new alpha value
                        pixels[i] = Aspose.Imaging.Color.FromArgb(200, c.R, c.G, c.B);
                    }

                    // Save the modified pixels back to the same frame
                    tiffImage.SavePixels(frame.Bounds, pixels);
                }

                // Save the processed TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}