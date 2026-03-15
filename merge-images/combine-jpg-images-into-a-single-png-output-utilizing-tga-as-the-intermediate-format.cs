using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPG files
            string[] jpgPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };

            // Temporary folder for intermediate TGA files
            string tempFolder = Path.Combine(Path.GetTempPath(), "TgaTemp");
            Directory.CreateDirectory(tempFolder);

            // List to hold paths of generated TGA files
            List<string> tgaPaths = new List<string>();

            // Convert each JPG to TGA
            foreach (string jpgPath in jpgPaths)
            {
                string tgaPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".tga");
                using (RasterImage jpgImage = (JpegImage)Image.Load(jpgPath))
                {
                    jpgImage.Save(tgaPath, new TgaOptions());
                }
                tgaPaths.Add(tgaPath);
            }

            // Collect sizes of TGA images
            List<Size> sizes = new List<Size>();
            foreach (string tgaPath in tgaPaths)
            {
                using (RasterImage tgaImage = (RasterImage)Image.Load(tgaPath))
                {
                    sizes.Add(tgaImage.Size);
                }
            }

            // Calculate canvas size for horizontal stitching
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Prepare PNG output options
            string outputPngPath = "combined.png";
            Source pngSource = new FileCreateSource(outputPngPath, false);
            PngOptions pngOptions = new PngOptions() { Source = pngSource };

            // Create PNG canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                // Merge each TGA image onto the canvas
                foreach (string tgaPath in tgaPaths)
                {
                    using (RasterImage tgaImage = (RasterImage)Image.Load(tgaPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, tgaImage.Width, tgaImage.Height);
                        canvas.SaveArgb32Pixels(bounds, tgaImage.LoadArgb32Pixels(tgaImage.Bounds));
                        offsetX += tgaImage.Width;
                    }
                }

                // Save the bound canvas
                canvas.Save();
            }

            // Cleanup temporary TGA files
            foreach (string tgaPath in tgaPaths)
            {
                if (File.Exists(tgaPath))
                    File.Delete(tgaPath);
            }

            // Remove temporary folder if empty
            if (Directory.Exists(tempFolder) && Directory.GetFiles(tempFolder).Length == 0)
                Directory.Delete(tempFolder);
        }
    }
}