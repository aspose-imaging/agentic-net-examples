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
        // Hardcoded input JPG paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output JPG path
        string outputPath = "output.jpg";

        // Verify each input file exists
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

        // Convert each JPG to a temporary TGA file
        List<string> tempTgaPaths = new List<string>();
        foreach (string jpgPath in inputPaths)
        {
            string tempTga = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(jpgPath) + ".tga");
            using (Image img = Image.Load(jpgPath))
            {
                img.Save(tempTga, new TgaOptions());
            }
            tempTgaPaths.Add(tempTga);
        }

        // Collect sizes of TGA images
        List<Size> sizes = new List<Size>();
        foreach (string tgaPath in tempTgaPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(tgaPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create JPEG canvas bound to the output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string tgaPath in tempTgaPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(tgaPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound JPEG image
            canvas.Save();
        }

        // Cleanup temporary TGA files
        foreach (string tgaPath in tempTgaPaths)
        {
            try { File.Delete(tgaPath); } catch { }
        }
    }
}