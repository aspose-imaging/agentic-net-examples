using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect at least two arguments: input JPEG files and output PNG file
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.png>");
                return;
            }

            // Separate input JPEG paths and output PNG path
            List<string> inputPaths = new List<string>();
            for (int i = 0; i < args.Length - 1; i++)
                inputPaths.Add(args[i]);
            string outputPngPath = args[args.Length - 1];

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizeList.Add(img.Size);
                }
            }

            // Calculate canvas size for horizontal stitching
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizeList)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create temporary TIFF file as intermediate canvas
            string tempTiffPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tif");
            Source tiffSource = new FileCreateSource(tempTiffPath, false);
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = tiffSource,
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            using (RasterImage tiffCanvas = (RasterImage)Image.Create(tiffOptions, newWidth, newHeight))
            {
                // Merge JPEG images horizontally onto TIFF canvas
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        tiffCanvas.SaveArgb32Pixels(bounds, pixels);
                        offsetX += img.Width;
                    }
                }

                // Save the bound TIFF canvas
                tiffCanvas.Save();
            }

            // Load the intermediate TIFF image
            using (RasterImage tiffImage = (RasterImage)Image.Load(tempTiffPath))
            {
                // Create PNG canvas bound to the final output path
                Source pngSource = new FileCreateSource(outputPngPath, false);
                PngOptions pngOptions = new PngOptions
                {
                    Source = pngSource
                };

                using (RasterImage pngCanvas = (RasterImage)Image.Create(pngOptions, tiffImage.Width, tiffImage.Height))
                {
                    // Copy pixels from TIFF to PNG canvas
                    int[] tiffPixels = tiffImage.LoadArgb32Pixels(tiffImage.Bounds);
                    pngCanvas.SaveArgb32Pixels(pngCanvas.Bounds, tiffPixels);

                    // Save the bound PNG canvas
                    pngCanvas.Save();
                }
            }

            // Clean up temporary TIFF file
            if (File.Exists(tempTiffPath))
                File.Delete(tempTiffPath);
        }
    }
}