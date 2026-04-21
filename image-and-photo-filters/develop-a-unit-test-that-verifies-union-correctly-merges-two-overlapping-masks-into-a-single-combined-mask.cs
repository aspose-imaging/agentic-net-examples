using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/source.jpg";
        string outputPath = "output/union_result.png";

        // Ensure input directory exists and create a blank source image if needed
        Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
        if (!File.Exists(inputPath))
        {
            var src = new FileCreateSource(inputPath, false);
            var jpegOpts = new JpegOptions { Source = src, Quality = 100 };
            using (JpegImage img = (JpegImage)Image.Create(jpegOpts, 10, 10))
            {
                img.Save(); // bound image
            }
        }

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                // Create two overlapping masks
                var mask1 = new Aspose.Imaging.MagicWand.ImageMasks.ImageBitMask(source);
                var mask2 = new Aspose.Imaging.MagicWand.ImageMasks.ImageBitMask(source);

                mask1.SetMaskPixel(2, 2, true);
                mask1.SetMaskPixel(3, 3, true);

                mask2.SetMaskPixel(3, 3, true);
                mask2.SetMaskPixel(4, 4, true);

                // Union the masks
                var unionMask = mask1.Union(mask2);

                // Verify that union contains all expected opaque pixels
                bool testA = unionMask.IsOpaque(2, 2);
                bool testB = unionMask.IsOpaque(3, 3);
                bool testC = unionMask.IsOpaque(4, 4);
                Console.WriteLine($"Union test results: {testA}, {testB}, {testC}");

                // Apply the union mask to the source image and save
                unionMask.Apply();
                var pngOpts = new PngOptions { Source = new FileCreateSource(outputPath, false) };
                source.Save(outputPath, pngOpts);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}