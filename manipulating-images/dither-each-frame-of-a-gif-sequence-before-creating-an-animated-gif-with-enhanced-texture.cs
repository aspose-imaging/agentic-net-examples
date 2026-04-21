using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing individual frame images
        string inputDirectory = @"C:\temp\frames";
        // Hardcoded output path for the animated GIF
        string outputPath = @"C:\temp\output_dithered.gif";

        try
        {
            // Verify the input directory exists and contains files
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            string[] frameFiles = Directory.GetFiles(inputDirectory);
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine($"No frame files found in: {inputDirectory}");
                return;
            }

            // Load the first frame, dither it, and create the initial GifImage
            using (Image firstImg = Image.Load(frameFiles[0]))
            {
                RasterImage firstRaster = (RasterImage)firstImg;
                // Apply Floyd‑Steinberg dithering with a 4‑bit palette
                firstRaster.Dither(DitheringMethod.FloydSteinbergDithering, 4);

                using (GifFrameBlock firstBlock = new GifFrameBlock(firstRaster))
                using (GifImage gifImage = new GifImage(firstBlock))
                {
                    // Process remaining frames
                    for (int i = 1; i < frameFiles.Length; i++)
                    {
                        string framePath = frameFiles[i];

                        // Input file existence check
                        if (!File.Exists(framePath))
                        {
                            Console.Error.WriteLine($"File not found: {framePath}");
                            return;
                        }

                        using (Image img = Image.Load(framePath))
                        {
                            RasterImage raster = (RasterImage)img;
                            raster.Dither(DitheringMethod.FloydSteinbergDithering, 4);

                            // Create a frame block from the dithered raster and add to GIF
                            GifFrameBlock block = new GifFrameBlock(raster);
                            gifImage.AddBlock(block);
                        }
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the animated GIF
                    gifImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}