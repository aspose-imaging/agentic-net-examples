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
            string inputDir = "Input";
            string outputPath = "ContactSheet.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var files = Directory.GetFiles(inputDir, "*.jpg");

            var thumbSizes = new List<Size>();
            var thumbFiles = new List<string>();

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage jpeg = (JpegImage)Image.Load(file))
                {
                    var thumb = jpeg.ExifData?.Thumbnail;
                    if (thumb != null)
                    {
                        thumbSizes.Add(thumb.Size);
                        thumbFiles.Add(file);
                    }
                }
            }

            if (thumbFiles.Count == 0)
            {
                Console.WriteLine("No thumbnails found.");
                return;
            }

            int totalWidth = thumbSizes.Sum(s => s.Width);
            int maxHeight = thumbSizes.Max(s => s.Height);

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions outOptions = new JpegOptions() { Source = outSource, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(outOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < thumbFiles.Count; i++)
                {
                    string file = thumbFiles[i];
                    using (JpegImage jpeg = (JpegImage)Image.Load(file))
                    {
                        var thumb = jpeg.ExifData?.Thumbnail;
                        if (thumb != null)
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                            canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                            offsetX += thumb.Width;
                        }
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