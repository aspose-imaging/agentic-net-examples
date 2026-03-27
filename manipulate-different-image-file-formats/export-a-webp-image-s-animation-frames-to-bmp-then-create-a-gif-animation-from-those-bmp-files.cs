using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input WebP file path
        string inputWebPPath = "input.webp";

        // Verify input file exists
        if (!File.Exists(inputWebPPath))
        {
            Console.Error.WriteLine($"File not found: {inputWebPPath}");
            return;
        }

        // Directory to store extracted BMP frames
        string bmpFramesDir = "frames";

        // Ensure the directory exists before any save operation
        Directory.CreateDirectory(Path.GetDirectoryName(bmpFramesDir));

        // Load the animated WebP image
        using (Image webpImage = Image.Load(inputWebPPath))
        {
            // Cast to multipage interface to access frames
            IMultipageImage multipage = webpImage as IMultipageImage;
            if (multipage == null || multipage.Pages == null || multipage.PageCount == 0)
            {
                Console.Error.WriteLine("The WebP image does not contain animation frames.");
                return;
            }

            // Extract each frame and save as BMP
            int frameIndex = 0;
            foreach (var page in multipage.Pages)
            {
                // Each page is a raster image
                RasterImage raster = page as RasterImage;
                if (raster == null)
                    continue;

                string bmpPath = Path.Combine(bmpFramesDir, $"frame_{frameIndex}.bmp");

                // Ensure the output directory exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                // Save the frame as BMP
                raster.Save(bmpPath, new BmpOptions());

                frameIndex++;
            }
        }

        // Path for the resulting GIF animation
        string outputGifPath = "output.gif";

        // Ensure the output directory exists before saving GIF
        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

        // Load the first BMP frame to initialize the GIF image
        string firstBmpPath = Path.Combine(bmpFramesDir, "frame_0.bmp");
        if (!File.Exists(firstBmpPath))
        {
            Console.Error.WriteLine($"File not found: {firstBmpPath}");
            return;
        }

        using (RasterImage firstFrame = (RasterImage)Image.Load(firstBmpPath))
        {
            // Create a GIF image using the first frame block
            using (GifImage gifImage = new GifImage(new GifFrameBlock(firstFrame)))
            {
                // Add remaining BMP frames to the GIF
                int index = 1;
                while (true)
                {
                    string bmpPath = Path.Combine(bmpFramesDir, $"frame_{index}.bmp");
                    if (!File.Exists(bmpPath))
                        break;

                    using (RasterImage frame = (RasterImage)Image.Load(bmpPath))
                    {
                        gifImage.AddPage(frame);
                    }

                    index++;
                }

                // Save the assembled GIF animation
                gifImage.Save(outputGifPath);
            }
        }
    }
}