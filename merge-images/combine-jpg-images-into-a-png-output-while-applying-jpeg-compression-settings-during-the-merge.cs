using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.jpg";
        string inputPath2 = "input2.jpg";
        string outputPath = "output.png";

        // Validate input files
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of input images
        List<Size> sizes = new List<Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizes.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizes.Add(img2.Size);
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = sizes[0].Width + sizes[1].Width;
        int newHeight = Math.Max(sizes[0].Height, sizes[1].Height);

        // Apply JPEG compression settings during merge using a temporary JPEG canvas
        string tempJpegPath = "temp_merge.jpg";
        Source jpegSource = new FileCreateSource(tempJpegPath, false);
        JpegOptions jpegOpts = new JpegOptions()
        {
            Source = jpegSource,
            Quality = 80 // Example JPEG quality setting
        };

        using (JpegImage jpegCanvas = (JpegImage)Image.Create(jpegOpts, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in new[] { inputPath1, inputPath2 })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    jpegCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the temporary JPEG canvas
            jpegCanvas.Save();
        }

        // Load the merged JPEG and copy its pixels to a PNG canvas
        using (RasterImage mergedJpeg = (RasterImage)Image.Load(tempJpegPath))
        {
            Source pngSource = new FileCreateSource(outputPath, false);
            PngOptions pngOpts = new PngOptions()
            {
                Source = pngSource
            };

            using (RasterImage pngCanvas = (RasterImage)Image.Create(pngOpts, newWidth, newHeight))
            {
                pngCanvas.SaveArgb32Pixels(new Rectangle(0, 0, newWidth, newHeight), mergedJpeg.LoadArgb32Pixels(mergedJpeg.Bounds));
                // Save the final PNG image
                pngCanvas.Save();
            }
        }

        // Optional: clean up temporary JPEG file
        if (File.Exists(tempJpegPath))
        {
            File.Delete(tempJpegPath);
        }
    }
}