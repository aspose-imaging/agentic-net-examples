using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();

            foreach (string file in imageFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string file in imageFiles)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
                    {
                        var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. A photographer can automatically stitch a series of portrait shots taken side‑by‑side into a single wide‑format JPEG for portfolio presentation.
 * 2. An e‑commerce platform can merge individual product angle photos stored in a folder into one composite image to display on a product listing page.
 * 3. A marketing team can combine daily social‑media banner images into a single horizontal collage for a weekly campaign recap.
 * 4. An accountant can concatenate scanned receipt JPEGs from a folder into one file for easy attachment to expense reports.
 * 5. A real‑estate agency can join room‑by‑room JPEG photos of a property into a single panoramic image for virtual tours.
 */