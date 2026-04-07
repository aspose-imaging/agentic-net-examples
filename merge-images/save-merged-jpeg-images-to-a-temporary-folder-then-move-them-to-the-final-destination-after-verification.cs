using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input JPEG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Temporary and final output locations
        string tempOutputPath = "Temp/merged.jpg";
        string finalOutputPath = "Output/merged.jpg";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions for horizontal merge
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Prepare JPEG options with a bound file source (temporary file)
        Source tempSource = new FileCreateSource(tempOutputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = tempSource,
            Quality = 100
        };

        // Create a JPEG canvas and merge images side by side
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas to the temporary file
            canvas.Save();
        }

        // Verify temporary file was created and move it to the final destination
        if (File.Exists(tempOutputPath))
        {
            if (File.Exists(finalOutputPath))
            {
                File.Delete(finalOutputPath);
            }
            File.Move(tempOutputPath, finalOutputPath);
            Console.WriteLine($"Merged image saved to: {finalOutputPath}");
        }
        else
        {
            Console.Error.WriteLine("Failed to create the merged image.");
        }
    }
}