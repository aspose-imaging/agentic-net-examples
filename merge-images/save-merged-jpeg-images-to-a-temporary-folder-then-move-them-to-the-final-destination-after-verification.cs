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
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = { "input1.jpg", "input2.jpg" };
            // Temporary and final output paths
            string tempOutputPath = "TempMerged\\merged.jpg";
            string finalOutputPath = "Merged\\merged.jpg";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure temporary directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create source and JPEG options for the output image
            Source source = new FileCreateSource(tempOutputPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = source, Quality = 90 };

            // Create a bound JPEG canvas and merge images
            using (JpegImage canvas = new JpegImage(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound image
                canvas.Save();
            }

            // Verify the temporary file and move to final destination
            if (File.Exists(tempOutputPath) && new FileInfo(tempOutputPath).Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));
                if (File.Exists(finalOutputPath))
                    File.Delete(finalOutputPath);
                File.Move(tempOutputPath, finalOutputPath);
            }
            else
            {
                Console.Error.WriteLine("Merged image verification failed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}