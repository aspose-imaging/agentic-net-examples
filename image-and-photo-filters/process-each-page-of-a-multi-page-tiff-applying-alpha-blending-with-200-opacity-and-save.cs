using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input\\multi_page.tif";
            string outputPath = "output\\processed.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image img = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)img;

                // Process each frame (page) of the TIFF
                foreach (TiffFrame frame in tiff.Frames)
                {
                    // Make the current frame active so that pixel operations target it
                    tiff.ActiveFrame = frame;

                    // Load all pixels of the active frame
                    Color[] pixels = tiff.LoadPixels(tiff.Bounds);

                    // Apply opacity of 200 (out of 255) to each pixel
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        Color src = pixels[i];
                        // Blend the original alpha with the desired opacity
                        int blendedAlpha = (src.A * 200) / 255;
                        pixels[i] = Color.FromArgb(blendedAlpha, src.R, src.G, src.B);
                    }

                    // Save the modified pixels back to the active frame
                    tiff.SavePixels(tiff.Bounds, pixels);
                }

                // Save the modified multi‑page TIFF to the output path
                tiff.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}