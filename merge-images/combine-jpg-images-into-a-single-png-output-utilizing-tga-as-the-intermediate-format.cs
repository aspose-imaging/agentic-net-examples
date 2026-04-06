using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Hardcoded output PNG file
        string outputPath = "output.png";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary folder for intermediate TGA files
        string tempFolder = "Temp";
        Directory.CreateDirectory(tempFolder);

        // List to hold paths of generated TGA files
        List<string> tgaPaths = new List<string>();

        // Convert each JPG to TGA
        foreach (string jpgPath in inputPaths)
        {
            string tgaPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".tga");
            using (RasterImage jpgImage = (JpegImage)Image.Load(jpgPath))
            {
                jpgImage.Save(tgaPath, new TgaOptions());
            }
            tgaPaths.Add(tgaPath);
        }

        // Collect sizes of TGA images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string tgaPath in tgaPaths)
        {
            using (RasterImage tgaImage = (RasterImage)Image.Load(tgaPath))
            {
                sizes.Add(tgaImage.Size);
            }
        }

        // Calculate canvas size for horizontal merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Prepare PNG options with bound source
        Source pngSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };

        // Create PNG canvas
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string tgaPath in tgaPaths)
            {
                using (RasterImage tgaImg = (RasterImage)Image.Load(tgaPath))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, tgaImg.Width, tgaImg.Height);
                    canvas.SaveArgb32Pixels(bounds, tgaImg.LoadArgb32Pixels(tgaImg.Bounds));
                    offsetX += tgaImg.Width;
                }
            }

            // Save the final PNG (file is already bound to source)
            canvas.Save();
        }

        // Cleanup temporary TGA files
        foreach (string tgaPath in tgaPaths)
        {
            try { File.Delete(tgaPath); } catch { }
        }
    }
}