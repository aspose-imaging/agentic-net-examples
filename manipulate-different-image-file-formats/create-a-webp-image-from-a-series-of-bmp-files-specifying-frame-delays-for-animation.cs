using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP files
        string inputDir = @"C:\temp\";
        string[] bmpFiles = new string[]
        {
            Path.Combine(inputDir, "frame1.bmp"),
            Path.Combine(inputDir, "frame2.bmp"),
            Path.Combine(inputDir, "frame3.bmp")
        };

        // Verify each input file exists
        foreach (var inputPath in bmpFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded output WebP file
        string outputPath = Path.Combine(inputDir, "animation.webp");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create WebP options for animation
        WebPOptions createOptions = new WebPOptions
        {
            Lossless = true,
            Quality = 100f,
            AnimBackgroundColor = (uint)Aspose.Imaging.Color.Gray.ToArgb(),
            AnimLoopCount = 0 // 0 means infinite loop
        };

        // Load the first BMP to obtain dimensions
        using (RasterImage firstBmp = (RasterImage)Image.Load(bmpFiles[0]))
        {
            int width = firstBmp.Width;
            int height = firstBmp.Height;

            // Create an empty animated WebP image with the specified options
            using (WebPImage webPImage = new WebPImage(width, height, createOptions))
            {
                // Add each BMP as a frame
                foreach (var bmpPath in bmpFiles)
                {
                    using (RasterImage bmp = (RasterImage)Image.Load(bmpPath))
                    {
                        // Create a frame block from the BMP raster image
                        WebPFrameBlock frameBlock = new WebPFrameBlock(bmp);
                        // Add the frame to the animated WebP
                        webPImage.AddBlock(frameBlock);
                    }
                }

                // Save the animated WebP file
                webPImage.Save(outputPath);
            }
        }
    }
}