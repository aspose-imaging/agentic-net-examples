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
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image img = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)img;

                // Process each frame
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    // Set the current frame as active
                    tiff.ActiveFrame = tiff.Frames[i];

                    // Load all pixels of the active frame
                    Aspose.Imaging.Color[] pixels = tiff.LoadPixels(tiff.ActiveFrame.Bounds);

                    // Apply opacity of 200 (out of 255) to each pixel
                    for (int p = 0; p < pixels.Length; p++)
                    {
                        Aspose.Imaging.Color c = pixels[p];
                        // Blend existing alpha with target opacity
                        byte newAlpha = (byte)Math.Min(255, (c.A * 200) / 255);
                        pixels[p] = Aspose.Imaging.Color.FromArgb(newAlpha, c.R, c.G, c.B);
                    }

                    // Save the modified pixels back to the frame
                    tiff.SavePixels(tiff.ActiveFrame.Bounds, pixels);
                }

                // Save the processed TIFF to the output path
                tiff.Save(outputPath);
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
 * 1. When a developer needs to add a semi‑transparent watermark to every page of a multi‑page TIFF document before archiving it, this C# Aspose.Imaging code can apply a uniform 200‑out‑of‑255 opacity across all frames.
 * 2. When a medical imaging application must reduce the opacity of scanned radiology TIFF frames to blend with a background color for better visualization, the code processes each page and adjusts the alpha channel accordingly.
 * 3. When a GIS system has to prepare multi‑page satellite TIFF tiles with consistent 200/255 opacity for overlay on a map canvas, the example demonstrates how to iterate through frames and apply the required alpha blending.
 * 4. When an e‑commerce platform wants to uniformly dim all pages of a product catalog TIFF so that promotional text can be overlaid later, this snippet shows how to modify each frame’s alpha values using C# and Aspose.Imaging.
 * 5. When a digital archiving workflow requires adjusting the alpha channel of each TIFF page to meet a publishing standard that mandates 78% opacity, the code provides a straightforward way to process and save the multi‑page TIFF with the desired opacity.
 */