using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect input JPG paths followed by the output JPG path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.jpg>");
            return;
        }

        // Separate input and output paths
        var inputPaths = args.Take(args.Length - 1).ToList();
        var outputPath = args[args.Length - 1];

        // Temporary folder for intermediate TGA files
        var tempFolder = Path.Combine(Path.GetTempPath(), "AsposeImaging_Temp_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempFolder);

        var tgaPaths = new List<string>();

        // Convert each JPG to TGA
        foreach (var jpgPath in inputPaths)
        {
            var tgaPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(jpgPath) + ".tga");
            using (RasterImage image = (RasterImage)Image.Load(jpgPath))
            {
                image.Save(tgaPath, new TgaOptions());
            }
            tgaPaths.Add(tgaPath);
        }

        // Collect sizes of TGA images
        var sizes = new List<Size>();
        foreach (var tgaPath in tgaPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(tgaPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with bound source
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = outputSource,
            Quality = 90
        };

        // Create JPEG canvas and merge images
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (var tgaPath in tgaPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(tgaPath))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound image (no need to pass path again)
            canvas.Save();
        }

        // Clean up temporary TGA files
        foreach (var tgaPath in tgaPaths)
        {
            try { File.Delete(tgaPath); } catch { }
        }
        try { Directory.Delete(tempFolder); } catch { }
    }
}